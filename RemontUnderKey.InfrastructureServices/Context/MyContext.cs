using Microsoft.EntityFrameworkCore;
using RemontUnderKey.Infrastructure.Models;
using RemontUnderKey.InfrastructureServices.Configurations;

namespace RemontUnderKey.InfrastructureServices.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        public DbSet<Job_Infra> Jobs { get; set; }
        public DbSet<TypeOfObject_Infra> Types { get; set; }
        public DbSet<KindOfJob_Infra> Kinds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region
            KindOfJob_Infra k1 = new KindOfJob_Infra
             {
                Id = 1,
                TitleOfKindOfJob = "Демонтажные работы",
                DescriptionOfKindOfJob = "В комплекс услуг по демонтажу не входит (вывоз строительного мусора, расфасовка по мешкам)." +
                " Эти виды услуг и цена огавариваются на обьекте, исходя из полученных в процессе демонтажных работ, обьемов мусора. " +
                "На все работы предоставляется договор, гарантия 5 лет. Работы производятся при помощи современного оборудования."
            };
            KindOfJob_Infra k2 = new KindOfJob_Infra
             {
                Id = 2,
                TitleOfKindOfJob = "Ремонт потолка",
                DescriptionOfKindOfJob = "В комплекс услуг по высококачественной подготовке потолка под окраску входит (3 слоя грунтовки, оклейка паутинки, " +
                "3 слоя шпатлевки, включая финишный слой, шлифовка под светодиодное освещение, окраска 3 слоя). На все работы предоставляется договор," +
                " гарантия 5 лет. Работы производятся при помощи современного оборудования."
            };

            KindOfJob_Infra k3 = new KindOfJob_Infra
             {
                Id = 3,
                TitleOfKindOfJob = "Ремонт стен",
                DescriptionOfKindOfJob = "В комплекс услуг по высококачественной подготовке стен под окраску входит (3 слоя грунтовки," +
                " оклейка паутинки, 3 слоя шпатлевки включая финишный слой, шлифовка при помощи светодиодного освещения, окраска 3 слоя)." +
                " В комплекс услуг по высококачесивенной подготовке стен под оклейку обоев входит (2 слоя грунтовки, " +
                "2 слоя шпатлевки включая финишный слой, шлифовка при помощи светодиодного освещения, оклейка обоями)." +
                " На все работы предоставляется договор, гарантия 5 лет. Работы производятся при помощи современного оборудования."

            };
            KindOfJob_Infra k4 = new KindOfJob_Infra
             {
                Id = 4,
                TitleOfKindOfJob = "Ремонт пола",
                DescriptionOfKindOfJob = "В комплекс услуги по ремонту пола не входят такие виды подготовительных работ как грунтовка." +
                " Цены на грунтовку смотрите выше по прейскуранту. Для подготовки пола достаточно нанест один слой грунтовки. " +
                "На все работы предоставляется договор, гарантия 5 лет. Работы производятся при помощи современного оборудования."
            };
            KindOfJob_Infra k5 = new KindOfJob_Infra
             {
                Id = 5,
                TitleOfKindOfJob = "Облицовка плиткой",
                DescriptionOfKindOfJob = "В  комплекс услуги по облицовке плиткой не входят такие виды подготовительных работ как грунтовка." +
                " Цены на грунтовку смотрите выше по прейскуранту.  На все работы предоставляется договор, гарантия 5 лет." +
                " Работы производятся при помощи современного оборудования"

            };
            KindOfJob_Infra k6 = new KindOfJob_Infra
            {
                Id = 6,
                TitleOfKindOfJob = "Электромонтажные работы",
                DescriptionOfKindOfJob = "В комплекс услуг по монтажу черновой электроточки входит (отверстие под электроточку," +
                " установка монтажной коробки). Черновой электроточкой также считается вывод под светильник, бра, люстра, и т.п. " +
                "Отдельной услугой считается (прокладка кабеля, гофры, штробление под электропроводку, заделка штроб)," +
                " эти виды услуг смотрите по прейскуранту цен ниже. На все работы предоставляется договор, гарантия 5 лет." +
                " Работы производятся при помощи современного оборудования."

            };
            KindOfJob_Infra k7 = new KindOfJob_Infra
            {
                Id = 7,
                TitleOfKindOfJob = "Сантехнические работы",
                DescriptionOfKindOfJob = "В комплекс услуг по монтажу черновой сантехнической точки входит" +
                " (разводка водопровода к точке потребления). Монтаж канализации, штробление, заделка сантехнических штроб, " +
                "установка сантехнических приборов, считается отдельно по прейскуранту цен ниже. На все работы предоставляется договор," +
                " гарантия 5 лет. Работы производятся при помощи современного оборудования."
            };
            #endregion
            #region
            TypeOfObject_Infra t1 = new TypeOfObject_Infra
            {
                Id = 1,
                TitleOfTypeOfObject = "Ремонт квартир",
                DescriptionOfTypeOfObject = ""
            };
            TypeOfObject_Infra t2 = new TypeOfObject_Infra
            {
                Id = 2,
                TitleOfTypeOfObject = "Ремонт коттеджей и домов",
                DescriptionOfTypeOfObject = ""
            };
            TypeOfObject_Infra t3 = new TypeOfObject_Infra
            {
                Id = 3,
                TitleOfTypeOfObject = "Ремонт офисов",
                DescriptionOfTypeOfObject = ""
            };
            TypeOfObject_Infra t4 = new TypeOfObject_Infra
            {
                Id = 4,
                TitleOfTypeOfObject = "Ремонт складов",
                DescriptionOfTypeOfObject = ""
            };
            TypeOfObject_Infra t5 = new TypeOfObject_Infra
            {
                Id = 5,
                TitleOfTypeOfObject = "Ремонт ресторанов и баров",
                DescriptionOfTypeOfObject = ""
            };
            TypeOfObject_Infra t6 = new TypeOfObject_Infra
            {
                Id = 6,
                TitleOfTypeOfObject = "Ремонт магазинов",
                DescriptionOfTypeOfObject = ""
            };
            #endregion
            #region
            UnitOfJob_Infra u1 = new UnitOfJob_Infra
            {
                Id = 1,
                TitleOfUnit = "шт."
            };
            UnitOfJob_Infra u2 = new UnitOfJob_Infra
            {
                Id = 2,
                TitleOfUnit = "м.кв."
            };
            UnitOfJob_Infra u3 = new UnitOfJob_Infra
            {
                Id = 3,
                TitleOfUnit = "м.п."
            };
            UnitOfJob_Infra u4 = new UnitOfJob_Infra
            {
                Id = 4,
                TitleOfUnit = "м.куб."
            };

            #endregion

            #region
            //KindOfJob - Демонтажные работы
            Job_Infra j1 = new Job_Infra
            {
                Id = 1,
                TitleOfJob = "Демонтаж перегородок (газосиликат)",
                PriceOfUnitOfJob = 7.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j2 = new Job_Infra
            {
                Id = 2,
                TitleOfJob = "Демонтаж перегородок (кирпич)",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j3 = new Job_Infra
            {
                Id = 3,
                TitleOfJob = "Демонтаж перегородок (бетон, не несущая)",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j4 = new Job_Infra
            {
                Id = 4,
                TitleOfJob = "Демонтаж перегородок (несущая)",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j5 = new Job_Infra
            {
                Id = 5,
                TitleOfJob = "Демонтаж стяжки пола",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j6 = new Job_Infra
            {
                Id = 6,
                TitleOfJob = "Демонтаж штукатурки",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j7 = new Job_Infra
            {
                Id = 7,
                TitleOfJob = "Демонтаж плитки",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j8 = new Job_Infra
            {
                Id = 8,
                TitleOfJob = "Демонтаж сантехнической точки",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j9 = new Job_Infra
            {
                Id = 9,
                TitleOfJob = "Демонтаж радиатора отопления",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j10 = new Job_Infra
            {
                Id = 10,
                TitleOfJob = "Демонтаж электроточки",
                PriceOfUnitOfJob = 1.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j11 = new Job_Infra
            {
                Id = 11,
                TitleOfJob = "Доставка материалов на объект",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j12 = new Job_Infra
            {
                Id = 12,
                TitleOfJob = "Подъём материалов на этаж с лифтом",
                PriceOfUnitOfJob = 0.6,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j13 = new Job_Infra
            {
                Id = 13,
                TitleOfJob = "Подъем материалов на этаж без лифта (цена умножается на количество подымаемых этажей)",
                PriceOfUnitOfJob = 0.6,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j14 = new Job_Infra
            {
                Id = 14,
                TitleOfJob = "Вынос строительного мусора   с лифтом (мешки до 50кг)",
                PriceOfUnitOfJob = 0.6,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j15 = new Job_Infra
            {
                Id = 15,
                TitleOfJob = "Вынос строительного мусора без лифта(цена умножается на количество подымаемых этажей, мешки до 50кг)",
                PriceOfUnitOfJob = 0.6,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j16 = new Job_Infra
            {
                Id = 16,
                TitleOfJob = "Вывоз строительного мусора (машина 3т, 20 кубов)",
                PriceOfUnitOfJob = 60.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j17 = new Job_Infra
            {
                Id = 17,
                TitleOfJob = "Вывоз строительного мусора ( машина 6т, 40 кубов)",
                PriceOfUnitOfJob = 115.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j18 = new Job_Infra
            {
                Id = 18,
                TitleOfJob = "Вывоз строительного мусора (машина 5т, 4 куба)",
                PriceOfUnitOfJob = 90.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j19 = new Job_Infra
            {
                Id = 19,
                TitleOfJob = "Вывоз строительного мусора (машина 10т, 12 кубов)",
                PriceOfUnitOfJob = 105.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j20 = new Job_Infra
            {
                Id = 20,
                TitleOfJob = "Вывоз строительного мусора (машина 20т, 16 кубов)",
                PriceOfUnitOfJob = 165.0,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j21 = new Job_Infra
            {
                Id = 21,
                TitleOfJob = "Расфасовка мусора по мешкам (считается разово при демонтажных работах," +
                " остальные расфасовки мусора, уборки помещения в процессе проведения работ входит " +
                "в стоимость всех последующих работ)",
                PriceOfUnitOfJob = 0.5,
                KindOfJob_InfraId = 1,
                UnitOfJob_InfraId = 1
            };
            #endregion

            #region
            //KindOfJob - Ремонт потолка
            Job_Infra j22 = new Job_Infra
            {
                Id = 22,
                TitleOfJob = "Штукатурка по маякам",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j23 = new Job_Infra
            {
                Id = 23,
                TitleOfJob = "Установка и демонтаж маяка",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j24 = new Job_Infra
            {
                Id = 24,
                TitleOfJob = "Штукатурка потолка по плоскости",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j25 = new Job_Infra
            {
                Id = 25,
                TitleOfJob = "Монтаж армирмирующей сетки",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j26 = new Job_Infra
            {
                Id = 26,
                TitleOfJob = "Монтаж ГКЛ (ровный)",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j27 = new Job_Infra
            {
                Id = 27,
                TitleOfJob = "Монтаж конструкций ГКЛ",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j28 = new Job_Infra
            {
                Id = 28,
                TitleOfJob = "Монтаж конструкций ГКЛ со скрытой подсветкой",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j29 = new Job_Infra
            {
                Id = 29,
                TitleOfJob = "Подготовка потолка к покраске",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j30 = new Job_Infra
            {
                Id = 30,
                TitleOfJob = "Подготовка потолка к покраске",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j31 = new Job_Infra
            {
                Id = 31,
                TitleOfJob = "Подготовка конструкций ГКЛ к покраске со скрытой подсветкой",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j32 = new Job_Infra
            {
                Id = 32,
                TitleOfJob = "Заделка стыков ГКЛ, проклейка ленты",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j33 = new Job_Infra
            {
                Id = 33,
                TitleOfJob = "Подготовка потолка ГКЛ к покраске",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j34 = new Job_Infra
            {
                Id = 34,
                TitleOfJob = "Упаковка стен, бумагой и либо специальной плёнкой перед покраской",
                PriceOfUnitOfJob = 0.5,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j35 = new Job_Infra
            {
                Id = 35,
                TitleOfJob = "Покраска потолка",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j36 = new Job_Infra
            {
                Id = 36,
                TitleOfJob = "Покраска конструкций ГКЛ",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j37 = new Job_Infra
            {
                Id = 37,
                TitleOfJob = "Покраска узких участков шириной менее 30 см",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j38 = new Job_Infra
            {
                Id = 38,
                TitleOfJob = "Покраска узких участков шириной менее 30 смОклейка, шпатлевание примыканий и окраска пенополистирольного," +
                " полиуретанового потолочного плинтуса до 5 см высотой (6см - по 5 у.е., 7 см - по 6 у.е., 8 см - по 7 у.е. за м.пог. И т.д.)",
                PriceOfUnitOfJob = 4.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            #endregion

            #region
            //KindOfJob - Ремонт стен
            Job_Infra j39 = new Job_Infra
            {
                Id = 39,
                TitleOfJob = "Монтаж перегородок (газосиликат )",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j40 = new Job_Infra
            {
                Id = 40,
                TitleOfJob = "Монтаж перегородок (шлакобетон)",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j41 = new Job_Infra
            {
                Id = 41,
                TitleOfJob = "Монтаж перегородок (кирпич)",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j42 = new Job_Infra
            {
                Id = 42,
                TitleOfJob = "Монтаж проемов, с перемычкой",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j43 = new Job_Infra
            {
                Id = 43,
                TitleOfJob = "Резка стяжки в местах где будут проходить перегородки",
                PriceOfUnitOfJob = 7.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j44 = new Job_Infra
            {
                Id = 44,
                TitleOfJob = "Монтаж перегородок ГКЛ",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j45 = new Job_Infra
            {
                Id = 45,
                TitleOfJob = "Укладка стекловаты",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j46 = new Job_Infra
            {
                Id = 46,
                TitleOfJob = "Штукатурка стен по плоскости",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j47 = new Job_Infra
            {
                Id = 47,
                TitleOfJob = "Штукатурка откосов по плоскости",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j48 = new Job_Infra
            {
                Id = 48,
                TitleOfJob = "Штукатурка колонн, узких участков по плоскости шириной менее 30 см",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j49 = new Job_Infra
            {
                Id = 49,
                TitleOfJob = "Монтаж армирмирующей сетки",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j50 = new Job_Infra
            {
                Id = 50,
                TitleOfJob = "Штукатурка стен по маякам",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j51 = new Job_Infra
            {
                Id = 51,
                TitleOfJob = "Установка и демонтаж маяка",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            #endregion
            modelBuilder.Entity<Job_Infra>().HasData();
            modelBuilder.Entity<KindOfJob_Infra>().HasData(k1, k2, k3, k4, k5, k6, k7);
            modelBuilder.Entity<TypeOfObject_Infra>().HasData(t1, t2, t3, t4, t5, t6);
            modelBuilder.Entity<UnitOfJob_Infra>().HasData();


            modelBuilder.ApplyConfiguration<Job_Infra>(new Job_Configuration());
            modelBuilder.ApplyConfiguration<KindOfJob_Infra>(new Kind_Configuration());
            modelBuilder.ApplyConfiguration<TypeOfObject_Infra>(new Type_Configuration());
            modelBuilder.ApplyConfiguration<UnitOfJob_Infra>(new Unit_Configuration());
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
