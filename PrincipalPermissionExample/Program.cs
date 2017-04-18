using System;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace PrincipalPermissionExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: I DID NOT GET THIS TO WORK! HELP :)

            // Attention: this could be language Specific.
            // find out your groups in a cmd box:
            // whoami /groups
            // tried: BUILTIN\Users, VORDEFINIERT\Benutzer, ...

            Thread.CurrentPrincipal = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            var myIdentity = Thread.CurrentPrincipal.Identity;

            //show some Information:
            Console.WriteLine("Username: {0}", myIdentity.Name);
            Console.WriteLine("Is in Administrators role: {0}", Thread.CurrentPrincipal.IsInRole(@"VORDEFINIERT\Administratoren"));


            try
            {
                // by code
                PrincipalPermission permCheck = new PrincipalPermission(
                                    null, @"VORDEFINIERT\Administratoren");
                permCheck.Demand();

                // by attribute
                AllowedAsWindowsUser();
                NeverAllowed();
            }
            catch (SecurityException e)
            {
                Console.WriteLine("I got a SecurityException: {0}", e.Message);
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "VORDEFINIERT\\Administratoren")]
        static void AllowedAsWindowsUser()
        {
            Console.WriteLine("OK");
        }
        [PrincipalPermission(SecurityAction.Demand, Role = "BUILTIN\\NonExistent")]
        static void NeverAllowed()
        {
            Console.WriteLine("You should not see this");
        }
    }
}
