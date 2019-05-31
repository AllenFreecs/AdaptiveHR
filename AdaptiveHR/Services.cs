using AdaptiveHR.Adaptive.BL.accrualtype;
using AdaptiveHR.Adaptive.BL.applicationschedule;
using AdaptiveHR.Adaptive.BL.approvergroup;
using AdaptiveHR.Adaptive.BL.approvergroupdetail;
using AdaptiveHR.Adaptive.BL.attendance;
using AdaptiveHR.Adaptive.BL.city;
using AdaptiveHR.Adaptive.BL.docs;
using AdaptiveHR.Adaptive.BL.education;
using AdaptiveHR.Adaptive.BL.emaillog;
using AdaptiveHR.Adaptive.BL.emailprofile;
using AdaptiveHR.Adaptive.BL.emailtemplate;
using AdaptiveHR.Adaptive.BL.employee;
using AdaptiveHR.Adaptive.BL.employeeupdates;
using AdaptiveHR.Adaptive.BL.humanresource;
using AdaptiveHR.Adaptive.BL.humanresourcestatus;
using AdaptiveHR.Adaptive.BL.invitation;
using AdaptiveHR.Adaptive.BL.job;
using AdaptiveHR.Adaptive.BL.leave;
using AdaptiveHR.Adaptive.BL.leavecredits;
using AdaptiveHR.Adaptive.BL.leavedetail;
using AdaptiveHR.Adaptive.BL.leaveparameter;
using AdaptiveHR.Adaptive.BL.leaveparameterdetail;
using AdaptiveHR.Adaptive.BL.leavetype;
using AdaptiveHR.Adaptive.BL.ob;
using AdaptiveHR.Adaptive.BL.ot;
using AdaptiveHR.Adaptive.BL.payrollitemtype;
using AdaptiveHR.Adaptive.BL.payrollupload;
using AdaptiveHR.Adaptive.BL.payslip;
using AdaptiveHR.Adaptive.BL.PDS;
using AdaptiveHR.Adaptive.BL.seminar;
using AdaptiveHR.Adaptive.BL.Settings;
using AdaptiveHR.Adaptive.BL.smslog;
using AdaptiveHR.Adaptive.BL.smsprofile;
using AdaptiveHR.Adaptive.BL.smstemplate;
using AdaptiveHR.Adaptive.BL.status;
using AdaptiveHR.Adaptive.BL.trainingdetail;
using AdaptiveHR.Adaptive.BL.trainingresponse;
using AdaptiveHR.Adaptive.BL.trainings;
using AdaptiveHR.Adaptive.BL.User;
using AdaptiveHR.Adaptive.BL.workschedule;
using AdaptiveHR.Util.Communication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdaptiveHR
{
    public static class Services
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IPDSBL, PDSBL>();
            services.AddScoped<IUserBL, UserBL>();
            services.AddScoped<SettingsBL, SettingsBL>();
            services.AddScoped<MailSender, MailSender>();
            services.AddScoped<IEmployeeBL, EmployeeBL>();
            services.AddScoped<IDocsBL, DocsBL>();
            services.AddScoped<IJobBL, JobBL>();
            services.AddScoped<IEducationBL, EducationBL>();
            services.AddScoped<ISeminarBL, SeminarBL>();
            services.AddScoped<IWorkScheduleBL, WorkScheduleBL>();
            services.AddScoped<ITrainingsBL, TrainingsBL>();
            services.AddScoped<ITrainingDetailBL, TrainingDetailBL>();
            services.AddScoped<ITrainingResponseBL, TrainingResponseBL>();
            services.AddScoped<IAttendanceBL, AttendanceBL>();
            services.AddScoped<IPayslipBL, PayslipBL>();
            services.AddScoped<IPayrollUploadBL, PayrollUploadBL>();
            services.AddScoped<IPayrollItemTypeBL, PayrollItemTypeBL>();
            services.AddScoped<ISMSProfileBL, SMSProfileBL>();
            services.AddScoped<ISMSLogBL, SMSLogBL>();
            services.AddScoped<IEmailProfileBL, EmailProfileBL>();
            services.AddScoped<IEmailLogBL, EmailLogBL>();
            services.AddScoped<ISMSTemplateBL, SMSTemplateBL>();
            services.AddScoped<IEmailTemplateBL, EmailTemplateBL>();
            services.AddScoped<IApplicationScheduleBL, ApplicationScheduleBL>();
            services.AddScoped<IOBBL, OBBL>();
            services.AddScoped<IOTBL, OTBL>();
            services.AddScoped<ILeaveBL, LeaveBL>();
            services.AddScoped<ILeaveTypeBL, LeaveTypeBL>();
            services.AddScoped<ILeaveDetailBL, LeaveDetailBL>();
            services.AddScoped<IApproverGroupBL, ApproverGroupBL>();
            services.AddScoped<IApproverGroupDetailBL, ApproverGroupDetailBL>();
            services.AddScoped<ILeaveCreditsBL, LeaveCreditsBL>();
            services.AddScoped<ILeaveParameterBL, LeaveParameterBL>();
            services.AddScoped<ILeaveParameterDetailBL, LeaveParameterDetailBL>();
            services.AddScoped<IAccrualTypeBL, AccrualTypeBL>();
            services.AddScoped<IEmployeeUpdatesBL, EmployeeUpdatesBL>();
            services.AddScoped<IStatusBL, StatusBL>();
            services.AddScoped<IHumanResourceBL, HumanResourceBL>();
            services.AddScoped<IHumanResourceStatusBL, HumanResourceStatusBL>();
            services.AddScoped<IInvitationBL, InvitationBL>();
            services.AddScoped<ICityBL, CityBL>();


        }
    }
}
