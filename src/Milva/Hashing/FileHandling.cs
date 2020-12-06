﻿using System;
using System.IO;
using System.Security.Cryptography;

/*  
    Milva: A simple, cross-platform command line tool for hashing files.
    Copyright(C) 2020 Samuel Lucas

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program. If not, see https://www.gnu.org/licenses/. 
*/

namespace Milva
{
    public static class FileHandling
    {
        public static byte[] HashFile(string filePath, HashAlgorithm hashAlgorithm)
        {
            try
            {
                const int bufferSize = 4096;
                using FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize, FileOptions.SequentialScan);
                return hashAlgorithm.ComputeHash(fileStream);
            }
            catch (Exception ex) when (ExceptionFilters.FileAccess(ex))
            {
                Console.WriteLine($"Error: {ex.GetType()}");
                return null;
            }
        }
    }
}
