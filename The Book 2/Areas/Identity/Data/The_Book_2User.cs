using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace The_Book_2.Areas.Identity.Data;

// Add profile data for application users by adding properties to the The_Book_2User class
public class The_Book_2User : IdentityUser
{
    public byte[]? ProfilePictureData { get; set; }
    public string? ProfilePictureMimeType { get; set; }
}

