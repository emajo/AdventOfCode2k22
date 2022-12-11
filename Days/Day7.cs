using System.Xml.Serialization;

class Day7
{
    public static int Part(bool partTwo)
    {
        var dir = Directory.GetCurrentDirectory();
        var sr = new StreamReader("inputs/day7.txt");
        Folder three = new Folder(null);
        Folder actualFolder = three;

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            var splittedLine = line.Split(' ');
            if (splittedLine[0] == "$")
            {
                if (splittedLine[1] == "cd")
                {
                    if(splittedLine[2] == "/")
                    {
                        actualFolder = three;
                    } else if (splittedLine[2] == "..")
                    {
                        actualFolder = actualFolder.ParentFolder ?? three;
                    } else
                    {
                        actualFolder = actualFolder.VisitChild(splittedLine[2]);
                    }
                }
            } else if (splittedLine[0] == "dir")
            {
                actualFolder.ChildFolders.Add(splittedLine[1], new Folder(actualFolder));
            } else
            {
                actualFolder.ChildFiles.Add(splittedLine[1], Convert.ToInt32(splittedLine[0]));
            }
        }
        sr.Close();

        if (!partTwo) return three.Resolve();

        int fsSize = 70000000;
        int spaceNeeded = 30000000;
        int freeSpace = fsSize - three.Size();
        return three.DetermineFolderToDelete(fsSize, spaceNeeded - freeSpace);

    }

}

class Folder
{
    public Folder? ParentFolder;
    // file name & size
    public Dictionary<string, int> ChildFiles;
    // folder name & obj
    public Dictionary<string, Folder> ChildFolders;

    public Folder(Folder parentFolder)
    {
        ParentFolder = parentFolder;
        ChildFiles = new Dictionary<string, int>();
        ChildFolders = new Dictionary<string, Folder>();
    }

    public Folder VisitChild(string name)
    {
        return ChildFolders[name];
    }
    public int Size()
    {
        int childFilesSize = ChildFiles.Sum(f => f.Value);
        int foldersFileSize = ChildFolders.Sum(f => f.Value.Size());
        return childFilesSize + foldersFileSize;
    }

    public int Resolve()
    {
        int folderSize = Size();
        int childFoldersResolveRes = ChildFolders.Sum(f => f.Value.Resolve());
        if (folderSize < 100000) return childFoldersResolveRes + folderSize;
        return childFoldersResolveRes;
    }

    public int DetermineFolderToDelete(int tempFolderToDelete, int spaceNeeded)
    {
        int folderSize = Size();

        if (folderSize > spaceNeeded) tempFolderToDelete = Math.Min(folderSize, tempFolderToDelete);

        if (ChildFolders.Count > 0)
        {
            int childFoldersTempFolderToDelete = ChildFolders.Min(f => f.Value.DetermineFolderToDelete(tempFolderToDelete, spaceNeeded));

            if (childFoldersTempFolderToDelete < tempFolderToDelete) return childFoldersTempFolderToDelete;
        }

        return tempFolderToDelete;
    }
}