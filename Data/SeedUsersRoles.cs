using Code1stUsersRoles.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

public class SeedUsersRoles
{
    private readonly List<CustomRole> _roles;
    private readonly List<CustomUser> _users;
    private readonly List<IdentityUserRole<string>> _userRoles;

    public SeedUsersRoles()
    {
        _roles = GetRoles();
        _users = GetUsers();
        _userRoles = GetUserRoles(_users, _roles);
    }

    public List<CustomRole> Roles { get { return _roles; } }
    public List<CustomUser> Users { get { return _users; } }
    public List<IdentityUserRole<string>> UserRoles { get { return _userRoles; } }

    private List<CustomRole> GetRoles()
    {
        var adminRole = new CustomRole("Admin") { Id = "1", NormalizedName = "ADMIN" };
        var contributorRole = new CustomRole("Contributor") { Id = "2", NormalizedName = "CONTRIBUTOR" };
        return new List<CustomRole> { adminRole, contributorRole };
    }

    private List<CustomUser> GetUsers()
    {
        var admin = new CustomUser
        {
            Id = "1",
            UserName = "a@a.a",
            NormalizedUserName = "A@A.A",
            Email = "a@a.a",
            NormalizedEmail = "A@A.A",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<CustomUser>().HashPassword(null, "P@$$w0rd"),
            SecurityStamp = "static-security-stamp-1",
            FirstName = "Admin",
            LastName = "User",
            IsApproved = true
        };

        var contributor = new CustomUser
        {
            Id = "2",
            UserName = "c@c.c",
            NormalizedUserName = "C@C.C",
            Email = "c@c.c",
            NormalizedEmail = "C@C.C",
            EmailConfirmed = true,
            PasswordHash = new PasswordHasher<CustomUser>().HashPassword(null, "P@$$w0rd"),
            SecurityStamp = "static-security-stamp-2",
            FirstName = "Contributor",
            LastName = "User",
            IsApproved = true
        };

        return new List<CustomUser> { admin, contributor };
    }

    private List<IdentityUserRole<string>> GetUserRoles(List<CustomUser> users, List<CustomRole> roles)
    {
        var userRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string> { UserId = users[0].Id, RoleId = roles[0].Id },
            new IdentityUserRole<string> { UserId = users[1].Id, RoleId = roles[1].Id }
        };
        return userRoles;
    }
}