var target = Argument("target", "ExecuteBuild");
var configuration = Argument("configuration", "Release");
var solutionFolder = "./";
var outputFolder = "./artifacts";

// If one want to target specifically one project
var myLibraryFolder = "./MyLibrary";
var myLibraryOutputFolder = "./myLibraryArtifacts";

//////////////////////////////////////////////////////////////////////
// TASKS
//////////////////////////////////////////////////////////////////////
Task("Clean")
    .Does(() => {
        CleanDirectory(outputFolder);
        CleanDirectory(myLibraryOutputFolder);
    });

Task("Restore")
    .Does(() => {
        DotNetRestore(solutionFolder);
    });

Task("Build")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore")
    .Does(() => {
        DotNetBuild(solutionFolder, new DotNetBuildSettings
        {
            NoRestore = true,
            Configuration = configuration
        });
    });

Task("Test")
    .IsDependentOn("Build")
    .Does(() => {
        DotNetTest(solutionFolder, new DotNetTestSettings
        {
            NoRestore = true, 
            Configuration = configuration,
            NoBuild = true
        });
    });

Task("Publish")
    .IsDependentOn("Test")
    .Does(() => {
        DotNetPublish(solutionFolder, new DotNetPublishSettings{
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = outputFolder
        });
    });

// Specific for MyLibraryFolder
Task("PublishLibrary")
    .IsDependentOn("Test")
    .Does(() => {
        DotNetPublish(myLibraryFolder, new DotNetPublishSettings{
            NoRestore = true,
            Configuration = configuration,
            NoBuild = true,
            OutputDirectory = myLibraryOutputFolder
        });
    });

Task("ExecuteBuild")
    .IsDependentOn("Publish")
    .IsDependentOn("PublishLibrary");

RunTarget(target);