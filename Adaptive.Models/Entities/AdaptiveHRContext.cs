using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Adaptive.Models.Entities
{
    public partial class AdaptiveHRContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContext;
        public AdaptiveHRContext()
        {
        }

        public AdaptiveHRContext(DbContextOptions<AdaptiveHRContext> options, IHttpContextAccessor httpContext)
            : base(options)
        {
            _httpContext = httpContext;
        }

        public virtual DbSet<AccrualType> AccrualType { get; set; }
        public virtual DbSet<ApplicationSchedule> ApplicationSchedule { get; set; }
        public virtual DbSet<ApproverGroup> ApproverGroup { get; set; }
        public virtual DbSet<ApproverGroupDetail> ApproverGroupDetail { get; set; }
        public virtual DbSet<Attendance> Attendance { get; set; }
        public virtual DbSet<Docs> Docs { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<EmailProfile> EmailProfile { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<EmployeeUpdates> EmployeeUpdates { get; set; }
        public virtual DbSet<HumanResource> HumanResource { get; set; }
        public virtual DbSet<HumanResourceStatus> HumanResourceStatus { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<Leave> Leave { get; set; }
        public virtual DbSet<LeaveCredits> LeaveCredits { get; set; }
        public virtual DbSet<LeaveDetail> LeaveDetail { get; set; }
        public virtual DbSet<LeaveParameter> LeaveParameter { get; set; }
        public virtual DbSet<LeaveParameterDetail> LeaveParameterDetail { get; set; }
        public virtual DbSet<LeaveType> LeaveType { get; set; }
        public virtual DbSet<Ob> Ob { get; set; }
        public virtual DbSet<Ot> Ot { get; set; }
        public virtual DbSet<PasswordHistory> PasswordHistory { get; set; }
        public virtual DbSet<PayrollItemType> PayrollItemType { get; set; }
        public virtual DbSet<PayrollUpload> PayrollUpload { get; set; }
        public virtual DbSet<Payslip> Payslip { get; set; }
        public virtual DbSet<Pds> Pds { get; set; }
        public virtual DbSet<Seminar> Seminar { get; set; }
        public virtual DbSet<Smslog> Smslog { get; set; }
        public virtual DbSet<Smsprofile> Smsprofile { get; set; }
        public virtual DbSet<Smstemplate> Smstemplate { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<TrainingDetail> TrainingDetail { get; set; }
        public virtual DbSet<TrainingResponse> TrainingResponse { get; set; }
        public virtual DbSet<Trainings> Trainings { get; set; }
        public virtual DbSet<UserGroup> UserGroup { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedule { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=NGSHS36YC2\\SQL2008;initial catalog=AdaptiveHR;persist security info=True;user id=sa;password=Allen@123$%^");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<AccrualType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApplicationSchedule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateScheduled).HasColumnType("datetime");

                entity.Property(e => e.IdPds).HasColumnName("ID_PDS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeScheduled).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApproverGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ApproverGroupDetail>(entity =>
            {
                entity.ToTable("ApproverGroup_Detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdApprover).HasColumnName("ID_Approver");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateAccepted).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.WorkDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Docs>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Path).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.Awards).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IdEducationLevel).HasColumnName("ID_EducationLevel");

                entity.Property(e => e.IdPds).HasColumnName("ID_PDS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdEmailProfile).HasColumnName("ID_EmailProfile");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmailProfile>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UseSsl).HasColumnName("UseSSL");
            });

            modelBuilder.Entity<EmailTemplate>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Attachment).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AndroidId).HasColumnName("AndroidID");

                entity.Property(e => e.ContractEndDate).HasColumnType("datetime");

                entity.Property(e => e.ContractStartDate).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EmployeeCode).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FaceRecognitionId).HasColumnName("FaceRecognitionID");

                entity.Property(e => e.FathersBirthDay).HasColumnType("datetime");

                entity.Property(e => e.FathersFirstName).IsUnicode(false);

                entity.Property(e => e.FathersLastName).IsUnicode(false);

                entity.Property(e => e.FathersMiddleName).IsUnicode(false);

                entity.Property(e => e.FathersName).IsUnicode(false);

                entity.Property(e => e.FingerPrintId).HasColumnName("FingerPrintID");

                entity.Property(e => e.IdBranch).HasColumnName("ID_Branch");

                entity.Property(e => e.IdDefaultSchedule).HasColumnName("ID_DefaultSchedule");

                entity.Property(e => e.IdDepartment).HasColumnName("ID_Department");

                entity.Property(e => e.IdDocAddress).HasColumnName("ID_DocAddress");

                entity.Property(e => e.IdEmployeeStatus).HasColumnName("ID_EmployeeStatus");

                entity.Property(e => e.IdPayScheme).HasColumnName("ID_PayScheme");

                entity.Property(e => e.IdPayrollParameter).HasColumnName("ID_PayrollParameter");

                entity.Property(e => e.IdPds).HasColumnName("ID_PDS");

                entity.Property(e => e.IdPosition).HasColumnName("ID_Position");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.MotherBirthDay).HasColumnType("datetime");

                entity.Property(e => e.MotherFirstName).IsUnicode(false);

                entity.Property(e => e.MotherMiddleName).IsUnicode(false);

                entity.Property(e => e.MothersMaidenLastName).IsUnicode(false);

                entity.Property(e => e.MothersName).IsUnicode(false);

                entity.Property(e => e.ObapproverGroup).HasColumnName("OBApproverGroup");

                entity.Property(e => e.OtapproverGroup).HasColumnName("OTApproverGroup");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .IsUnicode(false);

                entity.Property(e => e.SpouseBirthDay).HasColumnType("datetime");

                entity.Property(e => e.SpouseFirstName).IsUnicode(false);

                entity.Property(e => e.SpouseMaidenLastName).IsUnicode(false);

                entity.Property(e => e.SpouseMiddleName).IsUnicode(false);

                entity.Property(e => e.SpouseName).IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<EmployeeUpdates>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChangeNumber).IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdReason).HasColumnName("ID_Reason");

                entity.Property(e => e.IdStatus).HasColumnName("ID_Status");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<HumanResource>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IdCompany).HasColumnName("ID_Company");

                entity.Property(e => e.IdHumanResourceStatus).HasColumnName("ID_HumanResourceStatus");

                entity.Property(e => e.IdPds).HasColumnName("ID_PDS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<HumanResourceStatus>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.FirstName).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).IsUnicode(false);

                entity.Property(e => e.MiddleName).IsUnicode(false);

                entity.Property(e => e.Phonenumber).IsUnicode(false);

                entity.Property(e => e.SendSms).HasColumnName("SendSMS");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Job>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DescriptIon).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IdPds).HasColumnName("ID_PDS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Job1)
                    .HasColumnName("Job")
                    .IsUnicode(false);

                entity.Property(e => e.ReasonForLeaving).IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Leave>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IdLeaveType).HasColumnName("ID_LeaveType");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaveCredits>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Accrual).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdLeaveType).HasColumnName("ID_LeaveType");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaveDetail>(entity =>
            {
                entity.ToTable("Leave_Detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IdWorkType).HasColumnName("ID_WorkType");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaveParameter>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaveParameterDetail>(entity =>
            {
                entity.ToTable("LeaveParameter_detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdAccrualType).HasColumnName("ID_AccrualType");

                entity.Property(e => e.IdLeaveParameter).HasColumnName("ID_LeaveParameter");

                entity.Property(e => e.IdLeaveType).HasColumnName("ID_LeaveType");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<LeaveType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Ob>(entity =>
            {
                entity.ToTable("OB");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.IdTraining).HasColumnName("ID_Training");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Ot>(entity =>
            {
                entity.ToTable("OT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.Hours).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Otdate)
                    .HasColumnName("OTDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PasswordHistory>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdUser).HasColumnName("ID_User");

                entity.Property(e => e.Password).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PayrollItemType>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<PayrollUpload>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CutoffPeriodEndDate).HasColumnType("datetime");

                entity.Property(e => e.CutoffPeriodStartDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.UploadedFile).IsUnicode(false);
            });

            modelBuilder.Entity<Payslip>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdPayrollItemType).HasColumnName("ID_PayrollItemType");

                entity.Property(e => e.IdPayrollUpLoad).HasColumnName("ID_PayrollUpLoad");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.PayrollItem)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Pds>(entity =>
            {
                entity.ToTable("PDS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).IsUnicode(false);

                entity.Property(e => e.AskingSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.BirthDay).HasColumnType("datetime");

                entity.Property(e => e.CivilStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.CurrentAddress).IsUnicode(false);

                entity.Property(e => e.CurrentSalary).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.EmailAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress).IsUnicode(false);

                entity.Property(e => e.IdAwards).HasColumnName("ID_Awards");

                entity.Property(e => e.IdEducation).HasColumnName("ID_Education");

                entity.Property(e => e.IdJob).HasColumnName("ID_Job");

                entity.Property(e => e.IdSeminar).HasColumnName("ID_Seminar");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.Phic).HasColumnName("PHIC");

                entity.Property(e => e.SessionId)
                    .HasColumnName("SessionID")
                    .IsUnicode(false);

                entity.Property(e => e.Sss).HasColumnName("SSS");

                entity.Property(e => e.Tin).HasColumnName("TIN");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Seminar>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.IdPds).HasColumnName("ID_PDS");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Location).IsUnicode(false);

                entity.Property(e => e.Seminar1)
                    .HasColumnName("Seminar")
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Smslog>(entity =>
            {
                entity.ToTable("SMSLog");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IdSmsprofile).HasColumnName("ID_SMSProfile");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Smsprofile>(entity =>
            {
                entity.ToTable("SMSProfile");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Smstemplate>(entity =>
            {
                entity.ToTable("SMSTemplate");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Message)
                    .HasMaxLength(160)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrainingDetail>(entity =>
            {
                entity.ToTable("Training_detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateAccepted).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IdTrainingResponse).HasColumnName("ID_TrainingResponse");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.TrainingNote).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<TrainingResponse>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Name).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Trainings>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Obrequired).HasColumnName("OBRequired");

                entity.Property(e => e.Participants).IsUnicode(false);

                entity.Property(e => e.Training).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Guid)
                    .HasColumnName("GUID")
                    .IsUnicode(false);

                entity.Property(e => e.IdUserGroup).HasColumnName("ID_UserGroup");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.IsConfirmed).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordExpirationDate).HasColumnType("datetime");

                entity.Property(e => e.Token).IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.IdEmployee).HasColumnName("ID_Employee");

                entity.Property(e => e.IsActive).HasDefaultValueSql("((1))");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            });
        }
        public void AddAuditTimeStamp()
        {
            var entities = ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            int? userid = _httpContext.HttpContext.User.Identity.Name != null ? Convert.ToInt32(((ClaimsIdentity)_httpContext.HttpContext.User.Identity).FindFirst(ClaimTypes.Name).Value) : (int?)null;


            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    if (entity.Entity.GetType().GetProperty("CreatedDate") != null)
                    {
                        entity.Property("CreatedDate").CurrentValue = DateTime.UtcNow;
                    }

                    if (entity.Entity.GetType().GetProperty("UpdatedDate") != null)
                    {
                        entity.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
                    }

                    if (entity.Entity.GetType().GetProperty("CreatedBy") != null)
                    {
                        entity.Property("CreatedBy").CurrentValue = userid == null ? entity.Property("CreatedBy").CurrentValue == null ? 1 : entity.Property("CreatedBy").CurrentValue : userid;
                    }

                    if (entity.Entity.GetType().GetProperty("UpdatedBy") != null)
                    {
                        entity.Property("UpdatedBy").CurrentValue = userid == null ? entity.Property("UpdatedBy").CurrentValue == null ? 1 : entity.Property("UpdatedBy").CurrentValue : userid;
                    }
                }

                if (entity.State == EntityState.Modified)
                {
                    if (entity.Entity.GetType().GetProperty("UpdatedDate") != null)
                    {

                        entity.Property("UpdatedDate").CurrentValue = DateTime.UtcNow;
                    }

                    if (entity.Entity.GetType().GetProperty("UpdatedBy") != null)
                    {
                        entity.Property("UpdatedBy").CurrentValue = userid == null ? entity.Property("UpdatedBy").CurrentValue : userid;
                    }
                }
            }
        }

        public override int SaveChanges()
        {
            AddAuditTimeStamp();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            AddAuditTimeStamp();
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
