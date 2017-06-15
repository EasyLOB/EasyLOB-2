using EasyLOB.Data;
using EasyLOB.Library;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

namespace EasyLOB.Persistence
{
    public abstract class GenericRepositoryEF<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IZDataBase
    {
        #region Properties

        public virtual IZDataProfile DataProfile
        {
            get
            {
                Type type = this.GetRepositoryType<TEntity>();

                return DataHelper.GetDataProfile(type);
            }
        }

        public virtual string Entity
        {
            get { return typeof(TEntity).Name; }
        }

        public virtual int Joins
        {
            get { return 10; }
        }

        public virtual IQueryable<TEntity> Query
        {
            get
            {
                IQueryable<TEntity> query = Context.Set<TEntity>();
                query = Join(query);

                return query;
            }
        }

        public IUnitOfWork UnitOfWork { get; }

        #endregion Properties

        #region Properties Entity Framework

        public DbContext Context { get; protected set; }

        public IDbSet<TEntity> Set
        {
            get { return Context.Set<TEntity>(); }
        }

        #endregion Properties Entity Framework

        #region Methods

        public GenericRepositoryEF(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public virtual int Count(Expression<Func<TEntity, bool>> where)
        {
            int result;

            Filter(where);

            if (where != null)
            {
                result = Set.Where(where).Count();
            }
            else
            {
                result = Set.Count();
            }

            return result;
        }

        public virtual int Count(string where, object[] args = null)
        {
            int result;

            Filter(ref where, ref args);

            if (!String.IsNullOrEmpty(where))
            {
                if (args != null)
                {
                    result = Set.Where(where, args).Count();
                }
                else
                {
                    result = Set.Where(where).Count();
                }
            }
            else
            {
                result = Set.Count();
            }

            return result;
        }

        public virtual int CountAll()
        {
            return Set.Count();
        }

        public virtual bool Create(ZOperationResult operationResult, TEntity entity)
        {
            try
            {
                if (entity.BeforeCreate(operationResult))
                {
                    if (BeforeCreate(operationResult, entity))
                    {
                        //if (UnitOfWork.BeforeCreate(operationResult, entity))
                        {
                            object id = GetNextSequence();
                            if (id != null)
                            {
                                (entity as ZDataBase).SetId(new object[] { id });
                            }

                            Set.Add(entity);

                            if (entity.AfterCreate(operationResult))
                            {
                                AfterCreate(operationResult, entity);
                                //{
                                //    UnitOfWork.AfterCreate(operationResult, entity);
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                (operationResult as ZOperationResult).ParseExceptionEntityFramework(exception);
            }

            return operationResult.Ok;
        }

        public virtual bool Delete(ZOperationResult operationResult, TEntity entity)
        {
            try
            {
                entity = GetById(GetIds(entity));
                if (entity != null)
                {
                    if (entity.BeforeDelete(operationResult))
                    {
                        if (BeforeDelete(operationResult, entity))
                        {
                            //if (UnitOfWork.BeforeDelete(operationResult, entity))
                            {
                                Context.Entry(entity).State = EntityState.Deleted;

                                if (entity.AfterDelete(operationResult))
                                {
                                    AfterDelete(operationResult, entity);
                                    //{
                                    //    UnitOfWork.AfterDelete(operationResult, entity);
                                    //}
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                (operationResult as ZOperationResult).ParseExceptionEntityFramework(exception);
            }

            return operationResult.Ok;
        }

        public virtual void Filter(Expression<Func<TEntity, bool>> where)
        {
        }

        public virtual void Filter(ref string where, ref object[] args)
        {
            if (args != null)
            {
                // DateTime
                for (int i = 0; i < args.Length; i++)
                {
                    if (args[i] is string)
                    {
                        // "2000-01-01T23:59:59.999Z"
                        Regex regex = new Regex(@"[0-2][0-9][0-9][0-9]-[0-1][0-9]-[0-3][0-9]T[0-2][0-9]:[0-5][0-9]:[0-5][0-9].[0-9][0-9][0-9]Z");
                        Match match = regex.Match(args[i] as string);
                        if (match.Success)
                        {
                            args[i] = DateTime.ParseExact(args[i] as string, "yyyy-MM-ddTHH:mm:ss.fffZ",
                                System.Globalization.CultureInfo.InvariantCulture).Date;
                        }
                    }
                }
            }
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> where)
        {
            Filter(where);

            return Select(where, null, null, 1).FirstOrDefault();

            //return Query.Where(where).FirstOrDefault();
        }

        public virtual TEntity Get(string where, object[] args = null)
        {
            Filter(ref where, ref args);

            return Select(where, args, null, null, 1).FirstOrDefault();

            //return Query.Where(where).FirstOrDefault(); 
        }

        public virtual TEntity GetById(object id)
        {
            return GetById(new object[] { id });
        }

        public virtual TEntity GetById(object[] ids)
        {
            //return Set.Find(ids);

            string predicate = DataProfile.Class.LINQWhere;
            Expression<Func<TEntity, bool>> where =
                System.Linq.Dynamic.DynamicExpression.ParseLambda<TEntity, bool>(predicate, ids);

            return Get(where);
        }

        public virtual object[] GetIds(TEntity entity)
        {
            List<object> ids = new List<object>();

            foreach (string key in DataProfile.Class.Keys)
            {
                ids.Add(LibraryHelper.GetPropertyValue(entity, key));
            }

            return ids.ToArray();
        }

        public virtual object GetNextSequence()
        {
            object id = null;

            if (DataProfile.Class.IsIdentity && !PersistenceHelper.GeneratesIdentity(UnitOfWork.DBMS))
            {
                string sql = AdoNetHelper.GetSequenceSql(UnitOfWork.DBMS, this.GetType().Name);
                if (!String.IsNullOrEmpty(sql))
                {
                    id = Context.Database.SqlQuery<object>(sql);
                }
            }

            return id;
        }

        public virtual void Join(TEntity entity)
        {
            // Entity Framework Joins are server-side
        }

        public virtual void Join(IEnumerable<TEntity> enumerable)
        {
            /*
            // Entity Framework Joins are server-side

            if (enumerable != null)
            {
                int items = 0;
                foreach (TEntity entity in enumerable)
                {
                    Join(entity);

                    if (++items >= Joins)
                    {
                        break;
                    }
                }
            }
             */
        }

        public virtual IQueryable<TEntity> Join(IQueryable<TEntity> query)
        {
            return Join(query, DataProfile.Class.Associations);
        }

        public virtual IQueryable<TEntity> Join(IQueryable<TEntity> query, List<Expression<Func<TEntity, object>>> associations)
        {
            associations = associations != null && associations.Count() > 0 ?
                associations : LambdaHelper<TEntity>.ToFuncProperty(DataProfile.Class.Associations);

            if (query != null && associations != null)
            {
                //associations.ForEach(x => { query = query.Include(x); });

                foreach (Expression<Func<TEntity, object>> association in associations)
                {
                    query = query.Include(association);
                }
            }

            return query;
        }

        public virtual IQueryable<TEntity> Join(IQueryable<TEntity> query, string[] associations)
        {
            associations = associations != null && associations.Count() > 0 ?
                associations : DataProfile.Class.Associations;

            if (query != null && associations != null)
            {
                associations.ToList<string>().ForEach(x => { query = query.Include(x); });

                //foreach (string association in associations)
                //{
                //    query = query.Include(association);
                //}
            }

            return query;
        }

        public virtual IEnumerable<TEntity> Select(Expression<Func<TEntity, bool>> where = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            int? skip = null,
            int? take = null,
            List<Expression<Func<TEntity, object>>> associations = null)
        {
            IQueryable<TEntity> query = Set;

            Filter(where);

            if (where != null)
            {
                query = query.Where(where);
            }

            if (skip != null && orderBy == null)
            {
                query = query.OrderBy(DataProfile.Class.LINQOrderBy);
            }
            else if (orderBy != null)
            {
                query = orderBy(query);
            }

            // The method 'Skip' is only supported for sorted input in LINQ to Entities.
            // The method 'OrderBy' must be called before the method 'Skip'.
            if (skip != null && skip >= 0)
            {
                query = query.Skip((int)skip);
            }

            if (take != null && take > 0)
            {
                query = query.Take((int)take);
            }

            query = Join(query, associations);

            //return query.ToList<TEntity>();
            return query.AsNoTracking().ToList<TEntity>();
        }

        public virtual IEnumerable<TEntity> Select(string where = null,
            object[] args = null,
            string orderBy = null,
            int? skip = null,
            int? take = null,
            string[] associations = null)
        {
            IQueryable<TEntity> query = Set;

            Filter(ref where, ref args);

            if (!String.IsNullOrEmpty(where))
            {
                if (args != null)
                {
                    query = query.Where(where, args);
                }
                else
                {
                    query = query.Where(where);
                }
            }

            //if (orderBy != null && orderBy.Contains("LookupText"))
            //{
            //    orderBy = null;
            //}

            if (skip != null && String.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(DataProfile.Class.LINQOrderBy);
            }
            else if (!String.IsNullOrEmpty(orderBy))
            {
                query = query.OrderBy(orderBy);
            }

            // The method 'Skip' is only supported for sorted input in LINQ to Entities.
            // The method 'OrderBy' must be called before the method 'Skip'.
            if (skip != null && skip >= 0)
            {
                query = query.Skip((int)skip);
            }

            if (take != null && take > 0)
            {
                query = query.Take((int)take);
            }

            query = Join(query, associations);

            //return query.ToList<TEntity>();
            return query.AsNoTracking().ToList<TEntity>();
        }

        public virtual IEnumerable<TEntity> SelectAll()
        {
            return Query.ToList<TEntity>();
        }

        public void SetSequence(int value)
        {
        }

        public virtual bool Update(ZOperationResult operationResult, TEntity entity)
        {
            try
            {
                if (entity.BeforeUpdate(operationResult))
                {
                    if (BeforeUpdate(operationResult, entity))
                    {
                        //if (UnitOfWork.BeforeUpdate(operationResult, entity))
                        {
                            //Set.Attach(entity);
                            //Context.Entry(entity).State = EntityState.Modified;

                            Context.Set<TEntity>().AddOrUpdate(entity); // System.Data.Entity.Migrations

                            if (entity.AfterUpdate(operationResult))
                            {
                                AfterUpdate(operationResult, entity);
                                //{
                                //    UnitOfWork.AfterUpdate(operationResult, entity);
                                //}
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                (operationResult as ZOperationResult).ParseExceptionEntityFramework(exception);
            }

            return operationResult.Ok;
        }

        #endregion Methods

        #region Methods IDispose

        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                }

                disposed = true;
            }
        }

        #endregion Methods IDispose

        #region Triggers

        public virtual bool BeforeCreate(ZOperationResult operationResult, TEntity entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterCreate(ZOperationResult operationResult, TEntity entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeDelete(ZOperationResult operationResult, TEntity entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterDelete(ZOperationResult operationResult, TEntity entity)
        {
            return operationResult.Ok;
        }

        public virtual bool BeforeUpdate(ZOperationResult operationResult, TEntity entity)
        {
            return operationResult.Ok;
        }

        public virtual bool AfterUpdate(ZOperationResult operationResult, TEntity entity)
        {
            return operationResult.Ok;
        }

        #endregion Triggers

        #region Methods Entity Framework
        /*
        public TEntity AddOrUpdate(TEntity entity)
        {
            // The key to AddOrUpdate
            // https://blog.oneunicorn.com/2012/05/03/the-key-to-addorupdate    

            var tracked = Context.Set<TEntity>().Find(entity.GetId());
            if (tracked != null)
            {
                Context.Entry(tracked).CurrentValues.SetValues(entity);
                return tracked;
            }
            else
            {
                Context.Set<TEntity>().Add(entity);

                return entity;
            }
        }
         */
        #endregion Methods Entity Framework
    }
}