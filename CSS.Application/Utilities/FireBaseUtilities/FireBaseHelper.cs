using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;

namespace CSS.Application.Utilities.FireBaseUtilities;
public record FireBaseFile
{
    public string URL { get; set; } = default!;
    public string FileName { get; set; } = default!;

    public string Extension { get; set; } = default!;
}
public static class FireBaseHelper
{
    // Vulnurable Data
    private static string API_KEY = "AIzaSyDE0cOWUFDx5molFzragosxB9gg2YKmscU";
    private static string Bucket = "demofirebasestorage-2312e.appspot.com";
    private static string AuthEmail = "admin1@gmail.com";
    private static string AuthPassword = "Admin@@";
    public static async Task<FireBaseFile> UploadFileAsync(this IFormFile fileUpload)
    {
        FileInfo fileInfo = new FileInfo(fileUpload.FileName);

        if (fileUpload.Length > 0)
        {
            var fs = fileUpload.OpenReadStream();
            var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
            var a = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
            var cancellation = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(a.FirebaseToken),
                    ThrowOnCancel = true

                }
                ).Child("assets").Child(fileUpload.FileName)
                .PutAsync(fs, CancellationToken.None);
            try
            {
                var result = await cancellation;

                return new FireBaseFile
                {
                    FileName = fileUpload.FileName,
                    URL = result,
                    Extension = fileInfo.Extension
                };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }
        else throw new Exception("File is not existed!");
    }

    public static async Task<bool> RemoveFileAsync(this string fileName)
    {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
        var loginInfo = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
        var storage = new FirebaseStorage(Bucket, new FirebaseStorageOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(loginInfo.FirebaseToken),
            ThrowOnCancel = true
        });
        await storage.Child("assets").Child(fileName).DeleteAsync();
        return true;

    }

    public static async Task<string> GetLinkAsync(this string fileName)
    {
        var auth = new FirebaseAuthProvider(new FirebaseConfig(API_KEY));
        var loginInfo = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);
        var storage = new FirebaseStorage(Bucket, new FirebaseStorageOptions
        {
            AuthTokenAsyncFactory = () => Task.FromResult(loginInfo.FirebaseToken),
            ThrowOnCancel = true
        });

        var starRef = storage.Child("assets").Child(fileName);
        var dowloadURL = await starRef.GetDownloadUrlAsync();
        return dowloadURL;

    }

}