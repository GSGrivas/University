using Microsoft.AspNetCore.Identity;

//When adding this class, you need to change all occurences of "IdentityUser" into "AppUser"
namespace SportsStore.Models
{
    public class AppUser : IdentityUser
    {
        //Default value for avatar image(byte[0])
        public byte[] AvatarImage { get; set; } = new byte[0];
    }
}