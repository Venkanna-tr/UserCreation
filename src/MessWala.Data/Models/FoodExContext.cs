using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MessWala.Data.Models
{
    public partial class FoodExContext : DbContext
    {
        public FoodExContext() { }

        public FoodExContext(DbContextOptions<FoodExContext> options) : base(options) { }

        public virtual DbSet<AppMainMenus> AppMainMenus { get; set; }
        public virtual DbSet<AppRoleMenus> AppRoleMenus { get; set; }
        public virtual DbSet<AppSubMenus> AppSubMenus { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<LoginDeviceTypes> LoginDeviceTypes { get; set; }
        public virtual DbSet<LoginStatusTypes> LoginStatusTypes { get; set; }
        public virtual DbSet<OrderStatusTypes> OrderStatusTypes { get; set; }
        public virtual DbSet<PlanItems> PlanItems { get; set; }
        public virtual DbSet<PlanMasters> PlanMasters { get; set; }
        public virtual DbSet<Plans> Plans { get; set; }
        public virtual DbSet<ProofTypes> ProofTypes { get; set; }
        public virtual DbSet<RestaurantItems> RestaurantItems { get; set; }
        public virtual DbSet<RestaurantUsers> RestaurantUsers { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<StatusTypes> StatusTypes { get; set; }
        public virtual DbSet<SubscribedUsers> SubscribedUsers { get; set; }
        public virtual DbSet<SubscriptionTypes> SubscriptionTypes { get; set; }
        public virtual DbSet<UserCreds> UserCreds { get; set; }
        public virtual DbSet<UserLogs> UserLogs { get; set; }
        public virtual DbSet<UserOrderItems> UserOrderItems { get; set; }
        public virtual DbSet<UserOrders> UserOrders { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseNpgsql("Host=localhost;Database=FoodEx;Username=postgres;Password=postgrey12$");

                // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<AppMainMenus>(entity =>
            {
                entity.HasKey(e => e.AppMainMenuId)
                    .HasName("app_main_menus_pkey");

                entity.ToTable("app_main_menus", "food_ex_sch");

                entity.Property(e => e.AppMainMenuId)
                    .HasColumnName("app_main_menu_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.app_main_menus_app_main_menu_id_seq'::regclass)");

                entity.Property(e => e.IconPath).HasColumnName("icon_path");

                entity.Property(e => e.MenuText)
                    .IsRequired()
                    .HasColumnName("menu_text");

                entity.Property(e => e.NavPath).HasColumnName("nav_path");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.AppMainMenus)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_main_menus_status_type_id_fkey");
            });

            modelBuilder.Entity<AppRoleMenus>(entity =>
            {
                entity.HasKey(e => e.AppRoleId)
                    .HasName("app_role_menus_pkey");

                entity.ToTable("app_role_menus", "food_ex_sch");

                entity.Property(e => e.AppRoleId)
                    .HasColumnName("app_role_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.app_role_menus_app_role_id_seq'::regclass)");

                entity.Property(e => e.AppSubMenuId).HasColumnName("app_sub_menu_id");

                entity.Property(e => e.Canadd).HasColumnName("canadd");

                entity.Property(e => e.Candelete).HasColumnName("candelete");

                entity.Property(e => e.Canedit).HasColumnName("canedit");

                entity.Property(e => e.Canview).HasColumnName("canview");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.AppSubMenu)
                    .WithMany(p => p.AppRoleMenus)
                    .HasForeignKey(d => d.AppSubMenuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_role_menus_app_sub_menu_id_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AppRoleMenus)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_role_menus_role_id_fkey");
            });

            modelBuilder.Entity<AppSubMenus>(entity =>
            {
                entity.HasKey(e => e.AppSubMenuId)
                    .HasName("app_sub_menus_pkey");

                entity.ToTable("app_sub_menus", "food_ex_sch");

                entity.Property(e => e.AppSubMenuId)
                    .HasColumnName("app_sub_menu_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.app_sub_menus_app_sub_menu_id_seq'::regclass)");

                entity.Property(e => e.AppMainMenuId).HasColumnName("app_main_menu_id");

                entity.Property(e => e.IconPath).HasColumnName("icon_path");

                entity.Property(e => e.MenuText)
                    .IsRequired()
                    .HasColumnName("menu_text");

                entity.Property(e => e.NavPath).HasColumnName("nav_path");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.HasOne(d => d.AppMainMenu)
                    .WithMany(p => p.AppSubMenus)
                    .HasForeignKey(d => d.AppMainMenuId)
                    .HasConstraintName("app_sub_menus_app_main_menu_id_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.AppSubMenus)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("app_sub_menus_status_type_id_fkey");
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("categories_pkey");

                entity.ToTable("categories", "food_ex_sch");

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.categories_category_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("categories_status_type_id_fkey");
            });

            modelBuilder.Entity<LoginDeviceTypes>(entity =>
            {
                entity.HasKey(e => e.LoginDeviceTypeId)
                    .HasName("login_device_types_pkey");

                entity.ToTable("login_device_types", "food_ex_sch");

                entity.Property(e => e.LoginDeviceTypeId)
                    .HasColumnName("login_device_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.login_device_types_login_device_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<LoginStatusTypes>(entity =>
            {
                entity.HasKey(e => e.LoginStatusTypeId)
                    .HasName("login_status_types_pkey");

                entity.ToTable("login_status_types", "food_ex_sch");

                entity.Property(e => e.LoginStatusTypeId)
                    .HasColumnName("login_status_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.login_status_types_login_status_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<OrderStatusTypes>(entity =>
            {
                entity.HasKey(e => e.OrderStatusTypeId)
                    .HasName("order_status_types_pkey");

                entity.ToTable("order_status_types", "food_ex_sch");

                entity.Property(e => e.OrderStatusTypeId)
                    .HasColumnName("order_status_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.order_status_types_order_status_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<PlanItems>(entity =>
            {
                entity.HasKey(e => e.PlanItemId)
                    .HasName("plan_items_pkey");

                entity.ToTable("plan_items", "food_ex_sch");

                entity.Property(e => e.PlanItemId)
                    .HasColumnName("plan_item_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.plan_items_plan_item_id_seq'::regclass)");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Groupid).HasColumnName("groupid");

                entity.Property(e => e.Isdefaultitem).HasColumnName("isdefaultitem");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PlanItemsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plan_items_created_by_fkey");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.PlanItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plan_items_item_id_fkey");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.PlanItems)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plan_items_plan_id_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.PlanItems)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plan_items_status_type_id_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PlanItemsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("plan_items_updated_by_fkey");
            });

            modelBuilder.Entity<PlanMasters>(entity =>
            {
                entity.HasKey(e => e.PlanMasterId)
                    .HasName("plan_masters_pkey");

                entity.ToTable("plan_masters", "food_ex_sch");

                entity.Property(e => e.PlanMasterId)
                    .HasColumnName("plan_master_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.plan_masters_plan_master_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Plans>(entity =>
            {
                entity.HasKey(e => e.PlanId)
                    .HasName("plans_pkey");

                entity.ToTable("plans", "food_ex_sch");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.plans_plan_id_seq'::regclass)");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cost)
                    .HasColumnName("cost")
                    .HasColumnType("numeric(18,2)");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Imagename).HasColumnName("imagename");

                entity.Property(e => e.Imagepath).HasColumnName("imagepath");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.PlanMasterId).HasColumnName("plan_master_id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plans_category_id_fkey");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.PlansCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plans_created_by_fkey");

                entity.HasOne(d => d.PlanMaster)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.PlanMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plans_plan_master_id_fkey");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plans_restaurant_id_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Plans)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("plans_status_type_id_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.PlansUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("plans_updated_by_fkey");
            });

            modelBuilder.Entity<ProofTypes>(entity =>
            {
                entity.HasKey(e => e.ProofTypeId)
                    .HasName("proof_types_pkey");

                entity.ToTable("proof_types", "food_ex_sch");

                entity.Property(e => e.ProofTypeId)
                    .HasColumnName("proof_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.proof_types_proof_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RestaurantItems>(entity =>
            {
                entity.HasKey(e => e.ItemId)
                    .HasName("restaurant_items_pkey");

                entity.ToTable("restaurant_items", "food_ex_sch");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.restaurant_items_item_id_seq'::regclass)");

                entity.Property(e => e.AliasName).HasColumnName("alias_name");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Imagename).HasColumnName("imagename");

                entity.Property(e => e.Imagepath).HasColumnName("imagepath");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RestaurantItems)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_items_category_id_fkey");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RestaurantItemsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_items_created_by_fkey");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantItems)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_items_restaurant_id_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.RestaurantItems)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_items_status_type_id_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.RestaurantItemsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("restaurant_items_updated_by_fkey");
            });

            modelBuilder.Entity<RestaurantUsers>(entity =>
            {
                entity.HasKey(e => e.RestaurantUserId)
                    .HasName("restaurant_users_pkey");

                entity.ToTable("restaurant_users", "food_ex_sch");

                entity.Property(e => e.RestaurantUserId)
                    .HasColumnName("restaurant_user_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.restaurant_users_restaurant_user_id_seq'::regclass)");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Otherproof).HasColumnName("otherproof");

                entity.Property(e => e.ProofDocumentPath).HasColumnName("proof_document_path");

                entity.Property(e => e.ProofTypeId).HasColumnName("proof_type_id");

                entity.Property(e => e.RestaurantId).HasColumnName("restaurant_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RestaurantUsersCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_users_created_by_fkey");

                entity.HasOne(d => d.ProofType)
                    .WithMany(p => p.RestaurantUsers)
                    .HasForeignKey(d => d.ProofTypeId)
                    .HasConstraintName("restaurant_users_proof_type_id_fkey");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.RestaurantUsers)
                    .HasForeignKey(d => d.RestaurantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_users_restaurant_id_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.RestaurantUsers)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_users_status_type_id_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.RestaurantUsersUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("restaurant_users_updated_by_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RestaurantUsersUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurant_users_user_id_fkey");
            });

            modelBuilder.Entity<Restaurants>(entity =>
            {
                entity.HasKey(e => e.RestaurantId)
                    .HasName("restaurants_pkey");

                entity.ToTable("restaurants", "food_ex_sch");

                entity.Property(e => e.RestaurantId)
                    .HasColumnName("restaurant_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.restaurants_restaurant_id_seq'::regclass)");

                entity.Property(e => e.Address1).HasColumnName("address1");

                entity.Property(e => e.Address2).HasColumnName("address2");

                entity.Property(e => e.Address3).HasColumnName("address3");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.MobileNo).HasColumnName("mobile_no");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.RestaurantsCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurants_created_by_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("restaurants_status_type_id_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.RestaurantsUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("restaurants_updated_by_fkey");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("roles_pkey");

                entity.ToTable("roles", "food_ex_sch");

                entity.Property(e => e.RoleId)
                    .HasColumnName("role_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.roles_role_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roles_status_type_id_fkey");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Roles)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roles_user_type_id_fkey");
            });

            modelBuilder.Entity<StatusTypes>(entity =>
            {
                entity.HasKey(e => e.StatusTypeId)
                    .HasName("status_types_pkey");

                entity.ToTable("status_types", "food_ex_sch");

                entity.Property(e => e.StatusTypeId)
                    .HasColumnName("status_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.status_types_status_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<SubscribedUsers>(entity =>
            {
                entity.HasKey(e => e.SubscribedUserId)
                    .HasName("subscribed_users_pkey");

                entity.ToTable("subscribed_users", "food_ex_sch");

                entity.Property(e => e.SubscribedUserId)
                    .HasColumnName("subscribed_user_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.subscribed_users_subscribed_user_id_seq'::regclass)");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.FromDate).HasColumnName("from_date");

                entity.Property(e => e.PlanId).HasColumnName("plan_id");

                entity.Property(e => e.SubscriptionTypeId).HasColumnName("subscription_type_id");

                entity.Property(e => e.ToDate).HasColumnName("to_date");

                entity.Property(e => e.TotalDays).HasColumnName("total_days");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.SubscribedUsers)
                    .HasForeignKey(d => d.PlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscribed_users_plan_id_fkey");

                entity.HasOne(d => d.SubscriptionType)
                    .WithMany(p => p.SubscribedUsers)
                    .HasForeignKey(d => d.SubscriptionTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscribed_users_subscription_type_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.SubscribedUsers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("subscribed_users_user_id_fkey");
            });

            modelBuilder.Entity<SubscriptionTypes>(entity =>
            {
                entity.HasKey(e => e.SubscriptionTypeId)
                    .HasName("subscription_types_pkey");

                entity.ToTable("subscription_types", "food_ex_sch");

                entity.Property(e => e.SubscriptionTypeId)
                    .HasColumnName("subscription_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.subscription_types_subscription_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<UserCreds>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("user_creds_pkey");

                entity.ToTable("user_creds", "food_ex_sch");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.user_creds_user_id_seq'::regclass)");

                entity.Property(e => e.PasswordEncryption).HasColumnName("password_encryption");

                entity.Property(e => e.PasswordHash).HasColumnName("password_hash");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserCreds)
                    .HasForeignKey<UserCreds>(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_creds_user_id_fkey");
            });

            modelBuilder.Entity<UserLogs>(entity =>
            {
                entity.HasKey(e => e.UserLogId)
                    .HasName("user_logs_pkey");

                entity.ToTable("user_logs", "food_ex_sch");

                entity.Property(e => e.UserLogId)
                    .HasColumnName("user_log_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.user_logs_user_log_id_seq'::regclass)");

                entity.Property(e => e.ClientIp).HasColumnName("client_ip");

                entity.Property(e => e.DeviceModel).HasColumnName("device_model");

                entity.Property(e => e.LoginDeviceTypeId).HasColumnName("login_device_type_id");

                entity.Property(e => e.LoginStatusTypeId).HasColumnName("login_status_type_id");

                entity.Property(e => e.LogonTime).HasColumnName("logon_time");

                entity.Property(e => e.LogoutTime).HasColumnName("logout_time");

                entity.Property(e => e.SessionId).HasColumnName("session_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name");

                entity.HasOne(d => d.LoginDeviceType)
                    .WithMany(p => p.UserLogs)
                    .HasForeignKey(d => d.LoginDeviceTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_logs_login_device_type_id_fkey");

                entity.HasOne(d => d.LoginStatusType)
                    .WithMany(p => p.UserLogs)
                    .HasForeignKey(d => d.LoginStatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_logs_login_status_type_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogs)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_logs_user_id_fkey");
            });

            modelBuilder.Entity<UserOrderItems>(entity =>
            {
                entity.HasKey(e => e.UserOrderItemId)
                    .HasName("user_order_items_pkey");

                entity.ToTable("user_order_items", "food_ex_sch");

                entity.Property(e => e.UserOrderItemId)
                    .HasColumnName("user_order_item_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.user_order_items_user_order_item_id_seq'::regclass)");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.GroupId).HasColumnName("group_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.UserOrderId).HasColumnName("user_order_id");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.UserOrderItems)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_order_items_item_id_fkey");

                entity.HasOne(d => d.UserOrder)
                    .WithMany(p => p.UserOrderItems)
                    .HasForeignKey(d => d.UserOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_order_items_user_order_id_fkey");
            });

            modelBuilder.Entity<UserOrders>(entity =>
            {
                entity.HasKey(e => e.UserOrderId)
                    .HasName("user_orders_pkey");

                entity.ToTable("user_orders", "food_ex_sch");

                entity.Property(e => e.UserOrderId)
                    .HasColumnName("user_order_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.user_orders_user_order_id_seq'::regclass)");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.OrderStatusTypeId).HasColumnName("order_status_type_id");

                entity.Property(e => e.OrderedDate).HasColumnName("ordered_date");

                entity.Property(e => e.SubscribedUserId).HasColumnName("subscribed_user_id");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.HasOne(d => d.OrderStatusType)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.OrderStatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_orders_order_status_type_id_fkey");

                entity.HasOne(d => d.SubscribedUser)
                    .WithMany(p => p.UserOrders)
                    .HasForeignKey(d => d.SubscribedUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_orders_subscribed_user_id_fkey");
            });

            modelBuilder.Entity<UserTypes>(entity =>
            {
                entity.HasKey(e => e.UserTypeId)
                    .HasName("user_types_pkey");

                entity.ToTable("user_types", "food_ex_sch");

                entity.Property(e => e.UserTypeId)
                    .HasColumnName("user_type_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.user_types_user_type_id_seq'::regclass)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("users_pkey");

                entity.ToTable("users", "food_ex_sch");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasDefaultValueSql("nextval('food_ex_sch.users_user_id_seq'::regclass)");

                entity.Property(e => e.Address1).HasColumnName("address1");

                entity.Property(e => e.Address2).HasColumnName("address2");

                entity.Property(e => e.Address3).HasColumnName("address3");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedDate).HasColumnName("created_date");

                entity.Property(e => e.Email).HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.LastName).HasColumnName("last_name");

                entity.Property(e => e.MobileNo).HasColumnName("mobile_no");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.StatusTypeId).HasColumnName("status_type_id");

                entity.Property(e => e.UpdatedBy).HasColumnName("updated_by");

                entity.Property(e => e.UpdatedDate).HasColumnName("updated_date");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name");

                entity.Property(e => e.UserTypeId).HasColumnName("user_type_id");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.InverseCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_created_by_fkey");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_role_id_fkey");

                entity.HasOne(d => d.StatusType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StatusTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_status_type_id_fkey");

                entity.HasOne(d => d.UpdatedByNavigation)
                    .WithMany(p => p.InverseUpdatedByNavigation)
                    .HasForeignKey(d => d.UpdatedBy)
                    .HasConstraintName("users_updated_by_fkey");

                entity.HasOne(d => d.UserType)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("users_user_type_id_fkey");
            });

            modelBuilder.HasSequence<int>("app_main_menus_app_main_menu_id_seq");

            modelBuilder.HasSequence<int>("app_role_menus_app_role_id_seq");

            modelBuilder.HasSequence<int>("app_sub_menus_app_sub_menu_id_seq");

            modelBuilder.HasSequence<int>("categories_category_id_seq");

            modelBuilder.HasSequence<int>("login_device_types_login_device_type_id_seq");

            modelBuilder.HasSequence<int>("login_status_types_login_status_type_id_seq");

            modelBuilder.HasSequence<int>("order_status_types_order_status_type_id_seq");

            modelBuilder.HasSequence<int>("plan_items_plan_item_id_seq");

            modelBuilder.HasSequence<int>("plan_masters_plan_master_id_seq");

            modelBuilder.HasSequence<int>("plans_plan_id_seq");

            modelBuilder.HasSequence<int>("proof_types_proof_type_id_seq");

            modelBuilder.HasSequence<int>("restaurant_items_item_id_seq");

            modelBuilder.HasSequence<int>("restaurant_users_restaurant_user_id_seq");

            modelBuilder.HasSequence<int>("restaurants_restaurant_id_seq");

            modelBuilder.HasSequence<int>("roles_role_id_seq");

            modelBuilder.HasSequence<int>("status_types_status_type_id_seq");

            modelBuilder.HasSequence<int>("subscribed_users_subscribed_user_id_seq");

            modelBuilder.HasSequence<int>("subscription_types_subscription_type_id_seq");

            modelBuilder.HasSequence<int>("user_creds_user_id_seq");

            modelBuilder.HasSequence<int>("user_logs_user_log_id_seq");

            modelBuilder.HasSequence<int>("user_order_items_user_order_item_id_seq");

            modelBuilder.HasSequence<int>("user_orders_user_order_id_seq");

            modelBuilder.HasSequence<int>("user_types_user_type_id_seq");

            modelBuilder.HasSequence<int>("users_user_id_seq");
        }
    }
}