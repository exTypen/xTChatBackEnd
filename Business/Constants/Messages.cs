using Core.Entities.Concrete;

namespace Business.Constants;

public static class Messages
{
    //Auth
    public static readonly string UserNotFound = "Kullanıcı Bulunamadı";
    public static readonly string PasswordError = "Hatalı Şifre";
    public static readonly string SuccessfulLogin = "Giriş Başarılı";
    public static readonly string UserAlreadyExists = "Kullanıcı Adı Zaten Kayıtlı";
    public static readonly string AuthorizationDenied = "Yetersiz Yetki";
    public static readonly string NoJwt = "No JWT";
}