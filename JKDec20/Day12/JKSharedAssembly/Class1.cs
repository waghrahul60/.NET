using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JKSharedAssembly
{
    public class Class1
    {
        public string Hello()
        {
            return "Good afternoon";
        }
    }
}
/*
Steps to Make a shared assembly

- Generate the key pair
      sn -k file1.snk
 
- Sign the assembly with a "key pair"
     Assembly properties 

- Give the assembly "strong name"
      Build your assembly 

- Install the assembly into the GAC (Global Assembly Cache)
      gacutil /i Asm1.Dll


-----------------------------------------------------------
      gacutil /u Asm1  will uninstall it from Gac

before .net version 4 - c:\windows\assembly
version 4 onwards  - C:\Windows\Microsoft.NET\assembly\gac_msil
*/