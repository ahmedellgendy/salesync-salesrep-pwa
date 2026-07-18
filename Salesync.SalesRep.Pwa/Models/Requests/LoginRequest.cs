using System.ComponentModel.DataAnnotations;

namespace Salesync.SalesRep.Pwa.Models.Requests;

public sealed class LoginRequest
{
    [Required(ErrorMessage = "اسم المستخدم مطلوب.")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "كلمة المرور مطلوبة.")]
    public string Password { get; set; } = string.Empty;
}