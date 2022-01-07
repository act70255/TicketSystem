using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TicketSystem.Models.Utility
{
    public class BasicSeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new TicketSystem.Data.TicketSystemContext(serviceProvider.GetRequiredService<DbContextOptions<Data.TicketSystemContext>>()))
            {
                Debug.WriteLine($"BasicSeedData - Initialize");
                if (context.Account.Any())
                {
                    return;
                }

                var SAID = Guid.NewGuid().ToString();
                Account Account_SA = new Account { ID = SAID, Name = "SA", CreatorID = SAID };
                Account Account_QA = new Account { Name = "QA", CreatorID = SAID };
                Account Account_RD = new Account { Name = "RD", CreatorID = SAID };
                Account Account_PM = new Account { Name = "PM", CreatorID = SAID };
                Account Account_Admin = new Account { Name = "Administrator", CreatorID = SAID };

                Premission Premission_AccountCreate = new Premission { PremissionType = Premission.PremissionEnum.AccountCreate, CreatorID = SAID };
                Premission Premission_AccountModify = new Premission { PremissionType = Premission.PremissionEnum.AccountModify, CreatorID = SAID };
                Premission Premission_AccountView = new Premission { PremissionType = Premission.PremissionEnum.AccountView, CreatorID = SAID };
                Premission Premission_TicketCreate = new Premission { PremissionType = Premission.PremissionEnum.TicketCreate, CreatorID = SAID };
                Premission Premission_TicketModify = new Premission { PremissionType = Premission.PremissionEnum.TicketModify, CreatorID = SAID };
                Premission Premission_TicketView = new Premission { PremissionType = Premission.PremissionEnum.TicketView, CreatorID = SAID };
                Premission Premission_TicketResolve = new Premission { PremissionType = Premission.PremissionEnum.TicketResolve, CreatorID = SAID };
                Premission Premission_FeatureRequestView = new Premission { PremissionType = Premission.PremissionEnum.FeatureRequestView, CreatorID = SAID };
                Premission Premission_FeatureRequestCreate = new Premission { PremissionType = Premission.PremissionEnum.FeatureRequestCreate, CreatorID = SAID };
                Premission Premission_FeatureRequestResolve = new Premission { PremissionType = Premission.PremissionEnum.FeatureRequestResolve, CreatorID = SAID };
                Premission Premission_TestCaseCreate = new Premission { PremissionType = Premission.PremissionEnum.TestCaseCreate, CreatorID = SAID };
                Premission Premission_TestCaseView = new Premission { PremissionType = Premission.PremissionEnum.TestCaseView, CreatorID = SAID };
                Premission Premission_TestCaseResolve = new Premission { PremissionType = Premission.PremissionEnum.TestCaseResolve, CreatorID = SAID };

                Role Role_Admin = new Role { Name = "Admin", CreatorID = SAID };
                Role Role_QA = new Role { Name = "QA", CreatorID = SAID };
                Role Role_RD = new Role { Name = "RD", CreatorID = SAID };
                Role Role_PM = new Role { Name = "PM", CreatorID = SAID };

                try
                {
                context.Account.AddRange
                    (Account_SA,
                    Account_QA,
                    Account_RD,
                    Account_PM,
                    Account_Admin);
                context.SaveChanges();

                context.Role.AddRange
                    (Role_Admin,
                    Role_QA,
                    Role_RD,
                    Role_PM);
                context.SaveChanges();

                context.Premission.AddRange
                    (Premission_AccountCreate,
                    Premission_AccountModify,
                    Premission_AccountView,
                    Premission_TicketCreate,
                    Premission_TicketModify,
                    Premission_TicketView,
                    Premission_TicketResolve,
                    Premission_FeatureRequestView,
                    Premission_FeatureRequestCreate,
                    Premission_FeatureRequestResolve,
                    Premission_TestCaseCreate,
                    Premission_TestCaseView,
                    Premission_TestCaseResolve);
                context.SaveChanges();

                context.RolePremission.AddRange
                    (new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_AccountCreate.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_AccountModify.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_AccountView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TicketCreate.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TicketModify.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TicketView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TicketResolve.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_FeatureRequestCreate.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_FeatureRequestView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_FeatureRequestResolve.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TestCaseResolve.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TestCaseCreate.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_Admin.ID, PremissionID = Premission_TestCaseView.ID, CreatorID = SAID },

                    new RolePremission { RoleID = Role_QA.ID, PremissionID = Premission_TicketCreate.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_QA.ID, PremissionID = Premission_TicketModify.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_QA.ID, PremissionID = Premission_TicketView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_QA.ID, PremissionID = Premission_TestCaseCreate.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_QA.ID, PremissionID = Premission_TestCaseView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_QA.ID, PremissionID = Premission_TestCaseResolve.ID, CreatorID = SAID },

                    new RolePremission { RoleID = Role_RD.ID, PremissionID = Premission_TicketView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_RD.ID, PremissionID = Premission_TicketResolve.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_RD.ID, PremissionID = Premission_FeatureRequestView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_RD.ID, PremissionID = Premission_FeatureRequestResolve.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_RD.ID, PremissionID = Premission_TestCaseView.ID, CreatorID = SAID },

                    new RolePremission { RoleID = Role_PM.ID, PremissionID = Premission_TestCaseView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_PM.ID, PremissionID = Premission_FeatureRequestView.ID, CreatorID = SAID },
                    new RolePremission { RoleID = Role_PM.ID, PremissionID = Premission_FeatureRequestCreate.ID, CreatorID = SAID });

                context.AccountRole.AddRange
                    (new AccountRole { AccountID = Account_SA .ID, RoleID = Role_Admin .ID},
                    new AccountRole { AccountID = Account_QA.ID, RoleID = Role_QA.ID },
                    new AccountRole { AccountID = Account_RD.ID, RoleID = Role_RD.ID },
                    new AccountRole { AccountID = Account_PM.ID, RoleID = Role_PM.ID },
                    new AccountRole { AccountID = Account_Admin.ID, RoleID = Role_Admin.ID });
                
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex);
                }
            }
        }
    }
}
