﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.WindowsAzure.Commands.Common.Interfaces;
using Microsoft.WindowsAzure.Commands.Utilities.Common;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.Commands.Common.Models
{
    public class DiskDataStore : IDataStore
    {
        public void WriteFile(string path, string contents)
        {
            File.WriteAllText(path, contents);
        }

        public void WriteFile(string path, byte[] contents)
        {
            File.WriteAllBytes(path, contents);
        }

        public string ReadFileAsText(string path)
        {
            return File.ReadAllText(path);
        }

        public byte[] ReadFileAsBytes(string path)
        {
            return File.ReadAllBytes(path);
        }

        public Stream ReadFileAsStream(string path)
        {
            return File.Open(path, FileMode.Open, FileAccess.Read);
        }

        public void RenameFile(string oldPath, string newPath)
        {
            File.Move(oldPath, newPath);
        }

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public void DeleteFile(string path)
        {
            File.Delete(path);
        }

        public void EmptyDirectory(string dirPath)
        {
            foreach (var filePath in Directory.GetFiles(dirPath))
            {
                File.Delete(filePath);
            }
        }

        public X509Certificate2 GetCertificate(string thumbprint)
        {
            if (thumbprint == null)
            {
                return null;
            }
            else
            {
                return GeneralUtilities.GetCertificateFromStore(thumbprint);
            }
        }

        public void AddCertificate(X509Certificate2 cert)
        {
            GeneralUtilities.AddCertificateToStore(cert);
        }
    }
}
