USE EasyLOBIdentity
GO

SELECT
    AspNetUsers.UserName,
    AspNetUsers.Email,
    AspNetRoles.Name,
    Activity.Name,
    ActivityRole.Operations
FROM
    AspNetUsers
    LEFT JOIN AspNetUserRoles ON
        AspNetUserRoles.UserId = AspNetUsers.Id
    LEFT JOIN AspNetRoles ON
        AspNetRoles.Id = AspNetUserRoles.RoleId
    LEFT JOIN EasyLOBActivity..ActivityRole ON
        ActivityRole.RoleName = AspNetRoles.Name
    LEFT JOIN EasyLOBActivity..Activity ON
        Activity.Id = ActivityRole.ActivityId
ORDER BY
    1,3,4
