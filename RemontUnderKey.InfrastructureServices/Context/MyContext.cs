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
        //Ремонтные работы
        public DbSet<Job_Infra> Jobs { get; set; }
        //Виды ремонтных работ
        public DbSet<KindOfJob_Infra> Kinds { get; set; }
        //Фото выполненных ремонтных работ
        public DbSet<Photo_Infra> Photos { get; set; }
        //Завершенные обьекты ремонтных работ
        public DbSet<Repareobject_Infra> Repareobjects { get; set; }
        //Типы обьектов ремонта  
        public DbSet<TypeOfObject_Infra> Types { get; set; }
        //Единица измерения для расценки единицы ремонтной работы
        public DbSet<UnitOfJob_Infra> UnitOfJobs { get; set; }

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
            Job_Infra j52 = new Job_Infra
            {
                Id = 52,
                TitleOfJob = "Установка перфорированного угла",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j53 = new Job_Infra
            {
                Id = 53,
                TitleOfJob = "Штукатурка откосов по маякам",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j54 = new Job_Infra
            {
                Id = 54,
                TitleOfJob = "Штукатурка колонн, узких участков по маякам шириной менее 30 см",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j55 = new Job_Infra
            {
                Id = 55,
                TitleOfJob = "Подготовка стен к покраске",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j56 = new Job_Infra
            {
                Id = 56,
                TitleOfJob = "Подготовка откосов к покраске",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j57 = new Job_Infra
            {
                Id = 57,
                TitleOfJob = "Подготовка узких участков к покраске шириной менее 30 см",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j58 = new Job_Infra
            {
                Id = 58,
                TitleOfJob = "Подготовка стен под обои",
                PriceOfUnitOfJob = 6.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j59 = new Job_Infra
            {
                Id = 59,
                TitleOfJob = "Подготовка стен под декоративную штукатурку",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j60 = new Job_Infra
            {
                Id = 60,
                TitleOfJob = "Упаковка потолка, и специальной плёнкой перед покраской (для идеального примыкания)",
                PriceOfUnitOfJob = 0.5,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j61 = new Job_Infra
            {
                Id = 61,
                TitleOfJob = "Покраска стен",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j62 = new Job_Infra
            {
                Id = 62,
                TitleOfJob = "Покраска откосов",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j63 = new Job_Infra
            {
                Id = 63,
                TitleOfJob = "Покраска узких участков шириной менее 30 см",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j64 = new Job_Infra
            {
                Id = 64,
                TitleOfJob = "Оклейка стен обоями",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j65 = new Job_Infra
            {
                Id = 65,
                TitleOfJob = "Оклейка стен обоями с подбором рисунка",
                PriceOfUnitOfJob = 4.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j66 = new Job_Infra
            {
                Id = 66,
                TitleOfJob = "Декоративная штукатурка стен",
                PriceOfUnitOfJob = 6.0,
                KindOfJob_InfraId = 3,
                UnitOfJob_InfraId = 2
            };
            #endregion

            #region
            //KindOfJob - Ремонт пола
            Job_Infra j67 = new Job_Infra
            {
                Id = 67,
                TitleOfJob = "Черновая стяжка до 5 см",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j68 = new Job_Infra
            {
                Id = 68,
                TitleOfJob = "Черновая стяжка до 5 см",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j69 = new Job_Infra
            {
                Id = 69,
                TitleOfJob = "Чистовая стяжка (нивелир)",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j70 = new Job_Infra
            {
                Id = 70,
                TitleOfJob = "Укладка фанеры",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j71 = new Job_Infra
            {
                Id = 71,
                TitleOfJob = "Укладка фанеры на клей",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j72 = new Job_Infra
            {
                Id = 72,
                TitleOfJob = "Укладка шумоизоляции пола + листы ГВЛ (сухая стяжка пола)",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j73 = new Job_Infra
            {
                Id = 73,
                TitleOfJob = "Грунтовка пола",
                PriceOfUnitOfJob = 0.5,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j74 = new Job_Infra
            {
                Id = 74,
                TitleOfJob = "Покрытие пола, картоном, плёнкой перед покраской",
                PriceOfUnitOfJob = 0.5,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j75 = new Job_Infra
            {
                Id = 75,
                TitleOfJob = "Подгонка ламината, либо паркетной доски к плитке без установки порожка",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j76 = new Job_Infra
            {
                Id = 76,
                TitleOfJob = "Укладка ламината",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j77 = new Job_Infra
            {
                Id = 77,
                TitleOfJob = "Укладка ламината по диагонали",
                PriceOfUnitOfJob = 4.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j78 = new Job_Infra
            {
                Id = 78,
                TitleOfJob = "Укладка кварцвинила",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j79 = new Job_Infra
            {
                Id = 79,
                TitleOfJob = "Укладка кварцвинила по диагонали",
                PriceOfUnitOfJob = 4.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j80 = new Job_Infra
            {
                Id = 80,
                TitleOfJob = "Укладка пакетной доски",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j81 = new Job_Infra
            {
                Id = 81,
                TitleOfJob = "Укладка паркетной доски по диагонали",
                PriceOfUnitOfJob = 6.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j82 = new Job_Infra
            {
                Id = 82,
                TitleOfJob = "Укладка паркетной доски на клей",
                PriceOfUnitOfJob = 7.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j83 = new Job_Infra
            {
                Id = 83,
                TitleOfJob = "Укладка паркетной доски на клей по диагонали",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j84 = new Job_Infra
            {
                Id = 84,
                TitleOfJob = "Установка плинтуса пластикового",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j85 = new Job_Infra
            {
                Id = 85,
                TitleOfJob = "Установка плинтуса МДФ",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j86 = new Job_Infra
            {
                Id = 86,
                TitleOfJob = "Установка плинтуса пенополиуретан",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j87 = new Job_Infra
            {
                Id = 87,
                TitleOfJob = "Покраска пенополиуретанового плинтуса",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 4,
                UnitOfJob_InfraId = 3
            };
            #endregion

            #region
            //KindOfJob - Облицовка плиткой
            Job_Infra j88 = new Job_Infra
            {
                Id = 88,
                TitleOfJob = "Облицовка стен плиткой",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j89 = new Job_Infra
            {
                Id = 89,
                TitleOfJob = "Облицовка стен керамогранитом",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j90 = new Job_Infra
            {
                Id = 90,
                TitleOfJob = "Облицовка стен плиткой мозаичного типа",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j91 = new Job_Infra
            {
                Id = 91,
                TitleOfJob = "Облицовка плитки по диагонали",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j92 = new Job_Infra
            {
                Id = 92,
                TitleOfJob = "Облицовка стен декоративным кирпичом",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j93 = new Job_Infra
            {
                Id = 93,
                TitleOfJob = "Заполнение швов декоративного кирпича",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j94 = new Job_Infra
            {
                Id = 94,
                TitleOfJob = "Резка отверстий в плитке",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j95 = new Job_Infra
            {
                Id = 95,
                TitleOfJob = "Резка плитки под 45 градусов",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j96 = new Job_Infra
            {
                Id = 96,
                TitleOfJob = "Заусовка плитки",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j97 = new Job_Infra
            {
                Id = 97,
                TitleOfJob = "Резка керамогранита под 45 градусов",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j98 = new Job_Infra
            {
                Id = 98,
                TitleOfJob = "Заусовка керамогранита",
                PriceOfUnitOfJob = 7.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j99 = new Job_Infra
            {
                Id = 99,
                TitleOfJob = "Заполнение швов фугой",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j100 = new Job_Infra
            {
                Id = 100,
                TitleOfJob = "Обработка швов плитки",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j101 = new Job_Infra
            {
                Id = 101,
                TitleOfJob = "Заполнение швов эпоксидной фугой",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j102 = new Job_Infra
            {
                Id = 102,
                TitleOfJob = "Обработка швов после эпоксидной фуги",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j103 = new Job_Infra
            {
                Id = 103,
                TitleOfJob = "Монтаж экрана под ванну",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j104 = new Job_Infra
            {
                Id = 104,
                TitleOfJob = "Установка люка скрытого монтажа",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j105 = new Job_Infra
            {
                Id = 105,
                TitleOfJob = "Зашить инсталляцию, стояк",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 5,
                UnitOfJob_InfraId = 1
            };
            #endregion

            #region
            //KindOfJob - Электромонтажные работы
            Job_Infra j106 = new Job_Infra
            {
                Id = 106,
                TitleOfJob = "Монтаж черновой злектроточки",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j107 = new Job_Infra
            {
                Id = 107,
                TitleOfJob = "Перенос оптической розетки",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j108 = new Job_Infra
            {
                Id = 108,
                TitleOfJob = "Штробление в газосиликате",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j109 = new Job_Infra
            {
                Id = 109,
                TitleOfJob = "Штробление в кирпиче",
                PriceOfUnitOfJob = 2.5,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j110 = new Job_Infra
            {
                Id = 110,
                TitleOfJob = "Штробление в бетоне",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j111 = new Job_Infra
            {
                Id = 111,
                TitleOfJob = "Заделка штроб",
                PriceOfUnitOfJob = 1.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j112 = new Job_Infra
            {
                Id = 112,
                TitleOfJob = "Прокладка кабеля силового, слаботочного",
                PriceOfUnitOfJob = 0.8,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j113 = new Job_Infra
            {
                Id = 113,
                TitleOfJob = "Прокладка кабеля в гофре силового, слаботочного",
                PriceOfUnitOfJob = 1.3,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j114 = new Job_Infra
            {
                Id = 114,
                TitleOfJob = "Установка распаечной коробки",
                PriceOfUnitOfJob = 6.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j115 = new Job_Infra
            {
                Id = 115,
                TitleOfJob = "Установка электрощита в бетоне",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j116 = new Job_Infra
            {
                Id = 116,
                TitleOfJob = "Установка электрощита в газосиликате",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j117 = new Job_Infra
            {
                Id = 117,
                TitleOfJob = "Монтаж УЗО в щите",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j118 = new Job_Infra
            {
                Id = 118,
                TitleOfJob = "Монтаж автомата в щите",
                PriceOfUnitOfJob = 6.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j119 = new Job_Infra
            {
                Id = 119,
                TitleOfJob = "Установка пакетника",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j120 = new Job_Infra
            {
                Id = 120,
                TitleOfJob = "Монтаж распаечной коробки",
                PriceOfUnitOfJob = 8.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j121 = new Job_Infra
            {
                Id = 121,
                TitleOfJob = "Монтаж теплого пола",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 2
            };
            Job_Infra j122 = new Job_Infra
            {
                Id = 122,
                TitleOfJob = "Монтаж тёплого пола (укладка кабеля)",
                PriceOfUnitOfJob = 0.8,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j123 = new Job_Infra
            {
                Id = 123,
                TitleOfJob = "Установка регулятора тёплого пола",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j124 = new Job_Infra
            {
                Id = 124,
                TitleOfJob = "Установка розетки",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j125 = new Job_Infra
            {
                Id = 125,
                TitleOfJob = "Установка оптической розетки",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j126 = new Job_Infra
            {
                Id = 126,
                TitleOfJob = "Установка выключателя",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j127 = new Job_Infra
            {
                Id = 127,
                TitleOfJob = "Установка проходного выключателя",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j128 = new Job_Infra
            {
                Id = 128,
                TitleOfJob = "Установка точечного светильника",
                PriceOfUnitOfJob = 3.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j129 = new Job_Infra
            {
                Id = 129,
                TitleOfJob = "Установка бра",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j130 = new Job_Infra
            {
                Id = 130,
                TitleOfJob = "Установка трекового светильника",
                PriceOfUnitOfJob = 7.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j131 = new Job_Infra
            {
                Id = 131,
                TitleOfJob = "Установка светодиодной ленты",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j132 = new Job_Infra
            {
                Id = 132,
                TitleOfJob = "Установка трансформатора",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j133 = new Job_Infra
            {
                Id = 133,
                TitleOfJob = "Установка люстры",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j134 = new Job_Infra
            {
                Id = 134,
                TitleOfJob = "Резка отверстий под светильник",
                PriceOfUnitOfJob = 2.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j135 = new Job_Infra
            {
                Id = 135,
                TitleOfJob = "Установка вентилятора",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j136 = new Job_Infra
            {
                Id = 136,
                TitleOfJob = "Установка варочной панели",
                PriceOfUnitOfJob = 20.0,
                KindOfJob_InfraId = 6,
                UnitOfJob_InfraId = 1
            };
            #endregion

            #region
            //KindOfJob - Электромонтажные работы
            Job_Infra j137 = new Job_Infra
            {
                Id = 137,
                TitleOfJob = "Перенос радиатора (шитый полиэтилен, металлопласт)",
                PriceOfUnitOfJob = 80.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j138 = new Job_Infra
            {
                Id = 138,
                TitleOfJob = "Перенос полотенцесушителя (длинная перемычка, два крана)",
                PriceOfUnitOfJob = 80.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j139 = new Job_Infra
            {
                Id = 139,
                TitleOfJob = "Монтаж черновой сантехнической точки к точке потребления",
                PriceOfUnitOfJob = 20.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j140 = new Job_Infra
            {
                Id = 140,
                TitleOfJob = "Нарезка резьбы на металлических трубах",
                PriceOfUnitOfJob = 20.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j141 = new Job_Infra
            {
                Id = 141,
                TitleOfJob = "Установка счетчиков г/х воды",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j142 = new Job_Infra
            {
                Id = 142,
                TitleOfJob = "Установка фильтров тонкой очистки",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j143 = new Job_Infra
            {
                Id = 143,
                TitleOfJob = "Монтаж канализации к точке потребленияУстановка фильтров тонкой очистки",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j144 = new Job_Infra
            {
                Id = 144,
                TitleOfJob = "Штробление в газосиликате",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j145 = new Job_Infra
            {
                Id = 145,
                TitleOfJob = "Штробление в кирпиче",
                PriceOfUnitOfJob = 12.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j146 = new Job_Infra
            {
                Id = 146,
                TitleOfJob = "Штробление в бетоне",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j147 = new Job_Infra
            {
                Id = 147,
                TitleOfJob = "Заделка штроб",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 3
            };
            Job_Infra j148 = new Job_Infra
            {
                Id = 148,
                TitleOfJob = "Установка радиатора отопления",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j149 = new Job_Infra
            {
                Id = 149,
                TitleOfJob = "Установка отсекающих кранов",
                PriceOfUnitOfJob = 5.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j150 = new Job_Infra
            {
                Id = 150,
                TitleOfJob = "Установка инсталляции",
                PriceOfUnitOfJob = 100.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j151 = new Job_Infra
            {
                Id = 151,
                TitleOfJob = "Установка полотенцесушителя",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j152 = new Job_Infra
            {
                Id = 152,
                TitleOfJob = "Установка ванны акриловой",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j153 = new Job_Infra
            {
                Id = 153,
                TitleOfJob = "Установка ванны чугунной",
                PriceOfUnitOfJob = 40.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j154 = new Job_Infra
            {
                Id = 154,
                TitleOfJob = "Установка ванны угловой",
                PriceOfUnitOfJob = 40.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j155 = new Job_Infra
            {
                Id = 155,
                TitleOfJob = "Установка ванны с гидромассажем",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j156 = new Job_Infra
            {
                Id = 156,
                TitleOfJob = "Установка унитаза",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j157 = new Job_Infra
            {
                Id = 157,
                TitleOfJob = "Установка подвесного унитаза, кнопки",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j158 = new Job_Infra
            {
                Id = 158,
                TitleOfJob = "Установка умывальника",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j159 = new Job_Infra
            {
                Id = 159,
                TitleOfJob = "Установка умывальника с тумбочкой под умывальник",
                PriceOfUnitOfJob = 40.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j160 = new Job_Infra
            {
                Id = 160,
                TitleOfJob = "Установка крана",
                PriceOfUnitOfJob = 10.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j161 = new Job_Infra
            { 
                Id = 161,
                TitleOfJob = "Установка крана скрытого монтажа",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j162 = new Job_Infra
            {
                Id = 162,
                TitleOfJob = "Установка душевой стойки обычной",
                PriceOfUnitOfJob = 20.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j163 = new Job_Infra
            {
                Id = 163,
                TitleOfJob = "Установка душевой стойки с тропическим душем",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j164 = new Job_Infra
            {
                Id = 164,
                TitleOfJob = "Установка душевой стойки с тропическим душем",
                PriceOfUnitOfJob = 40.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j165 = new Job_Infra
            {
                Id = 165,
                TitleOfJob = "Установка шторки на ванну",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j166 = new Job_Infra
            {
                Id = 166,
                TitleOfJob = "Установка раздвижной системы на ванну",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j167 = new Job_Infra
            {
                Id = 167,
                TitleOfJob = "Установка биде",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j168 = new Job_Infra
            {
                Id = 168,
                TitleOfJob = "Установка подвесного биде",
                PriceOfUnitOfJob = 35.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j169 = new Job_Infra
            {
                Id = 169,
                TitleOfJob = "Установка трапа для душевой кабины с поддоном",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j170 = new Job_Infra
            {
                Id = 170,
                TitleOfJob = "Установка трапа скрытого монтажа",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j171 = new Job_Infra
            {
                Id = 171,
                TitleOfJob = "Установка душевой кабины без поддона",
                PriceOfUnitOfJob = 80.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j172 = new Job_Infra
            {
                Id = 172,
                TitleOfJob = "Установка душевой кабины с поддоном",
                PriceOfUnitOfJob = 50.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j173 = new Job_Infra
            {
                Id = 173,
                TitleOfJob = "Установка душевой кабины (бокс с гидромассажем)",
                PriceOfUnitOfJob = 100.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j174 = new Job_Infra
            {
                Id = 174,
                TitleOfJob = "Установка бойлера",
                PriceOfUnitOfJob = 30.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j175 = new Job_Infra
            {
                Id = 175,
                TitleOfJob = "Установка стиральной машины",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            Job_Infra j176 = new Job_Infra
            {
                Id = 176,
                TitleOfJob = "Установка посудомоечной машины",
                PriceOfUnitOfJob = 15.0,
                KindOfJob_InfraId = 7,
                UnitOfJob_InfraId = 1
            };
            #endregion

            modelBuilder.Entity<Job_Infra>().HasData(j1, j2, j3, j4, j5, j6, j7, j8, j9, j10, j11, j12, j13, j14, j15, j16, j17, j18, j19, j20,
                                                     j21, j22, j23, j24, j25, j26, j27, j28, j29, j30, j31, j32, j33, j34, j35, j36, j37, j38, j39, j40,
                                                     j41, j42, j43, j44, j45, j46, j47, j48, j49, j50, j51, j52, j53, j54, j55, j56, j57, j58, j59, j60,
                                                     j61, j62, j63, j64, j65, j66, j67, j68, j69, j70, j71, j72, j73, j74, j75, j76, j77, j78, j79, j80,
                                                     j81, j82, j83, j84, j85, j86, j87, j88, j89, j90, j91, j92, j93, j94, j95, j96, j97, j98, j99, j100,
                                                     j101, j102, j103, j104, j105, j106, j107, j108, j109, j110, j111, j112, j113, j114, j115, j116, j117, j118, j119, j120,
                                                     j121, j122, j123, j124, j125, j126, j127, j128, j129, j130, j131, j132, j133, j134, j135, j136, j137, j138, j139, j140,
                                                     j141, j142, j143, j144, j145, j146, j147, j148, j149, j150, j151, j152, j153, j154, j155, j156, j157, j158, j159, j160,
                                                     j161, j162, j163, j164, j165, j166, j167, j168, j169, j170, j171, j172, j173, j174, j175, j176);
            modelBuilder.Entity<KindOfJob_Infra>().HasData(k1, k2, k3, k4, k5, k6, k7);
            modelBuilder.Entity<Photo_Infra>().HasData();
            modelBuilder.Entity<Repareobject_Infra>().HasData();
            modelBuilder.Entity<TypeOfObject_Infra>().HasData(t1, t2, t3, t4, t5, t6);
            modelBuilder.Entity<UnitOfJob_Infra>().HasData(u1, u2, u3);


            modelBuilder.ApplyConfiguration<Job_Infra>(new Job_Configuration());
            modelBuilder.ApplyConfiguration<KindOfJob_Infra>(new Kind_Configuration());
            modelBuilder.ApplyConfiguration<TypeOfObject_Infra>(new Type_Configuration());
            modelBuilder.ApplyConfiguration<UnitOfJob_Infra>(new Unit_Configuration());
            modelBuilder.ApplyConfiguration<Repareobject_Infra>(new Repareobject_Configuration());
            modelBuilder.ApplyConfiguration<Photo_Infra>(new Photo_Configuration());

            

            base.OnModelCreating(modelBuilder);
        }
    }
}
