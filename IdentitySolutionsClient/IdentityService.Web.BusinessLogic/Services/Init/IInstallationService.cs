

namespace IdentityService.Web.BusinessLogic.Services.Init;

public interface IInitServiceWeb
{
    bool Init();
    
    // Is the application connected to the database?
    bool IsDatabaseConnected();
    
    // Is the application installed?
    bool IsInstalled();
    
    //bool InstallApplication(InstallModel model);
    
    InstallationModel InstallApplication(InstallationModel model);
}

public class InitServiceWeb : IInitServiceWeb
{
    IInstallationService _installationService;
    
    public InitServiceWeb()
    {
        _installationService = new InstallationService();
    }
    public bool Init()
    {
        throw new NotImplementedException();
    }

    public bool IsDatabaseConnected()
    {
        return false;
    }

    public bool IsInstalled()
    {
        return false;
    }

    public InstallationModel InstallApplication(InstallationModel model)
    {
        _installationService.InstallStep1Async(model).Wait();
        return model;

    }
}


public interface IInstallationService
{
    // Install the application step 1
    //Task<bool> InstallStep1Async(InstallStep1Model model);
    
    Task<bool> InstallStep1Async(InstallationModel model);

}

public class InstallationService: IInstallationService
{
    public Task<bool> InstallStep1Async(InstallationModel model)
    {
        throw new NotImplementedException();
    }
}
public class InstallationModel
{
    public DatabaseType DatabaseType { get; set; }
    public string ConnectionString { get; set; }
    public string AdminEmail { get; set; }
    public string AdminUserName { get; set; }
    public string AdminPassword { get; set; }
    public string AdminPasswordConfirm { get; set; }
}

public enum DatabaseType
{
    MsSql,
    Sqlite,
    PostgreSql,
    MSSQlS,
}