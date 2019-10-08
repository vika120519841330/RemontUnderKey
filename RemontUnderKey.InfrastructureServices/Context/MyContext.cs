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
        public DbSet<UnitOfJob_Infra> Units { get; set; }
        //Комментарии зарегистрированных пользователей
        public DbSet<Comment_Infra> Comments { get; set; }
        //Заявки на звонок пользователей
        public DbSet<CallMee_Infra> Calls { get; set; }
        //Этапы работ
        public DbSet<Stage_Infra> Stages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //KindOfJob
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

            //TypeOfObject
            #region
            TypeOfObject_Infra t1 = new TypeOfObject_Infra
            {
                Id = 1,
                TitleOfTypeOfObject = "РЕМОНТ И ОТДЕЛКА КВАРТИР,",
                ImgSrc = "/Content/Advertising/flat.jpg",
                DescriptionOfTypeOfObject = "Мы обладаем ресурсами и опытом выполнения полного цикла ремонта квартир под ключ " +
                                            "без привлечения сторонних подрядчиков. Заказывая его у нас, вы получаете " +
                                            "гарантированно высокое качество. "
            };
            TypeOfObject_Infra t2 = new TypeOfObject_Infra
            {
                Id = 2,
                TitleOfTypeOfObject = " КОТТЕДЖЕЙ, ТАУНХАУСОВ, ДОМОВ,",
                ImgSrc = "/Content/Advertising/house.jpg",
                DescriptionOfTypeOfObject = "Загородный дом – ваша крепость. Важно чувствовать себя в нем защищенными, как приятно наслаждаться комфортом " +
                                            "и красотой. Шум, пыль городов толкают все большее количество людей " +
                                            "задумываться о приобретении собственных домов, куда можно было бы сбежать от мирской суеты. " +
                                            "Дом для человека не просто тихая гавань, где он может набраться сил и снова ринуться в вечную борьбу за достойную жизнь. " +
                                            "Дом - это место, где случаются истории, где растут наши дети, где наши эмоции укрепляют стены нервных систем человека. " +
                                            "Что нужно для человека, чтоб быть счастливым? Место, куда хотелось бы возвращаться, где хотелось бы быть. " +
                                            "Предлагаем качественный ремонт коттеджей, таунхаусов и домов по приемлемым ценам."
            };
            TypeOfObject_Infra t3 = new TypeOfObject_Infra
            {
                Id = 3,
                TitleOfTypeOfObject = " ОФИСОВ,",
                ImgSrc = "/Content/Advertising/office.jpg",
                DescriptionOfTypeOfObject = "Опыт нашей работы показывает, что переоценить пользу хорошей отделки, выполненной бригадой грамотных " +
                                            "мастеров, в коммерческих помещениях невозможно. Зачем она необходима? Чтобы обеспечить комфортные условия " +
                                            "для сотрудников, для удачного зонирования пространства, создать положительный образ в глазах клиентов, " +
                                            "привлечь партнеров, для которых продуманная обстановка станет дополнительным показателем благонадежности, " +
                                            "подчеркнуть имидж компании, ее отношение к окружающим; для умелой и ненавязчивой рекламы. " +
                                            "Ремонт офисов под ключ – это правильный шаг для любой организации после покупки или аренды нового помещения, " +
                                            "а также в случае, если маркетинговая концепция изменилась, запланированы перемены, руководство хочет идти в ногу " +
                                            " со временем. "
            };
            TypeOfObject_Infra t4 = new TypeOfObject_Infra
            {
                Id = 4,
                TitleOfTypeOfObject = " СКЛАДОВ, ПРОИЗВОДСТВЕННЫХ ПЛОЩАДЕЙ,",
                ImgSrc = "/Content/Advertising/storage.jpg",
                DescriptionOfTypeOfObject = "Ремонт складов, несмотря на простоту дизайна, должен обеспечить максимальную эффективность для использования площадей. " +
                                            "Поэтому здесь важна планировка помещения, правильное ее зонирование, обеспечение согласованности между ними. " +
                                            "Если в складском помещении предполагается применение специальной техники, то во время ремонта складов должны " +
                                            "учитываться все особенности помещения. Осуществляя ремонт складов, мы выполняем все действия, направленные на " +
                                            "улучшение условий эксплуатации указанных помещений. При этом, делаем ставку на высокое качество работы и надёжность её результата." +
                                            "Мы гарантируем Вам лояльные цены на фоне профессионального подхода к решению соответствующих задач."
            };
            TypeOfObject_Infra t5 = new TypeOfObject_Infra
            {
                Id = 5,
                TitleOfTypeOfObject = " МАГАЗИНОВ,",
                ImgSrc = "/Content/Advertising/shop.jpg",
                DescriptionOfTypeOfObject = "Предлагаем полный цикл ремонтно-отделочных работ, включающий: " +
                                            "быстрый ремонт в арендуемом либо собственном помещении; " +
                                            "демонтажные работы; " +
                                            "возведение стен и перегородок; " +
                                            "малярно - штукатурные работы; " +
                                            "установка дверей и другие столярно - плотницкие работы; " +
                                            "проводка электрики и установка окончательных приборов; " +
                                            "сантехнические работы; " +
                                            "вентиляционные работы; " +
                                            "разводка кабелей для слаботочного оборудования, " +
                                            "установка окончательных приборов и пуско - наладочные работы; " +
                                            "ремонтно - косметические работы в заведении без его закрытия(остановки); " +
                                            "комплексные работы по монтажу входной группы, рекламной вывески и отделке фасада. "
            };
            TypeOfObject_Infra t6 = new TypeOfObject_Infra
            {
                Id = 6,
                TitleOfTypeOfObject = " ГАРАЖЕЙ,",
                ImgSrc = "/Content/Advertising/garage.jpg",
                DescriptionOfTypeOfObject = "Каждый автолюбитель следит не только за состоянием своего автомобиля, но и за помещением в котором он содержится. " +
                                            "Нахождение авто в теплом, ухоженном и оборудованном боксе благоприятно сказывается на работе транспортного средства. " +
                                            "Кроме того, вопрос безопасности и сохранности авто отпадает сам собой. Однако в ходе эксплуатации помещение гаража " +
                                            "нужно ремонтировать. Может потребоваться капитальный или небольшой косметический ремонт. Своими руками проделать " +
                                            "отделочные и ремонтные работы можно. Но если нет опыта, времени и желания, то лучше привлечь специалистов. " +
                                            "Капитальный ремонт гаража, производимый нашими усилиями, предполагает полный спектр услуг по ремонту. "
            };
            TypeOfObject_Infra t7 = new TypeOfObject_Infra
            {
                Id = 7,
                TitleOfTypeOfObject = " РЕСТОРАНОВ И КАФЕ",
                ImgSrc = "/Content/Advertising/bar.jpg",
                DescriptionOfTypeOfObject = "Обновлённая отделка кафе и ресторанов часто становится эффективным способом для повышения популярности заведения. " +
                                            "Грамотная перепланировка, изменения в дизайне и стилистике оформления помещений позволит сделать заведение более комфортным " +
                                            "и соответствующим ведущим модным тенденциям. При этом ремонт помещения кафе должен быть выполнен безупречно. " +
                                            "Любые ошибки будут стоить очень дорого. Именно поэтому стоит воспользоваться услугами профессионалов, " +
                                            "которые смогут учесть не только технические тонкости, связанные с особенностями работы заведения, но и сделать ремонт помещения " +
                                            "под кафе или ресторан идеально качественно. "
            };

            #endregion

            //UnitOfJob
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

            //KindOfJob - Демонтажные работы
            #region
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

            //KindOfJob - Ремонт потолка
            #region
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
                " полиуретанового потолочного плинтуса до 5 см высотой (6см - по 5 у.е., 7 см - по 6 у.е., 8 см - по 7 у.е. за м.пог. и т.д.)",
                PriceOfUnitOfJob = 4.0,
                KindOfJob_InfraId = 2,
                UnitOfJob_InfraId = 3
            };
            #endregion

            //KindOfJob - Ремонт стен
            #region
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

            //KindOfJob - Ремонт пола
            #region
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

            //KindOfJob - Облицовка плиткой
            #region
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

            //KindOfJob - Электромонтажные работы
            #region
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

            //Job
            #region
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

            //Repareobject
            #region
            Repareobject_Infra o1 = new Repareobject_Infra
            {
                Id = 1,
                AddressOfRepareobject = "г.Минск, ул.Ложинская",
                TypeOfObject_InfraId = 1
            };
            Repareobject_Infra o2 = new Repareobject_Infra
            {
                Id = 2,
                AddressOfRepareobject = "Минский р-н, д.Копище, ул.Подгорная",
                TypeOfObject_InfraId = 1
            };
            Repareobject_Infra o3 = new Repareobject_Infra
            {
                Id = 3,
                AddressOfRepareobject = "Минский р-н, а.г.Сёмково",
                TypeOfObject_InfraId = 2
            };
            #endregion

            //Обьект ремонта - "г.Минск, ул.Ложинская"
            #region
            Photo_Infra p1 = new Photo_Infra
            {
                Id = 1,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/1.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/1.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p2 = new Photo_Infra
            {
                Id = 2,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/2.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/2.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p3 = new Photo_Infra
            {
                Id = 3,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/3.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/3.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p4 = new Photo_Infra
            {
                Id = 4,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/4.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/4.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p5 = new Photo_Infra
            {
                Id = 5,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/5.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/5.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p6 = new Photo_Infra
            {
                Id = 6,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/6.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/6.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p7 = new Photo_Infra
            {
                Id = 7,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/7.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/7.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p8 = new Photo_Infra
            {
                Id = 8,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/8.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/8.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p9 = new Photo_Infra
            {
                Id = 9,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/9.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/9.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p10 = new Photo_Infra
            {
                Id = 10,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/10.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/10.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p11 = new Photo_Infra
            {
                Id = 11,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/11.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/11.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p12 = new Photo_Infra
            {
                Id = 12,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/12.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/12.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p13 = new Photo_Infra
            {
                Id = 13,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/13.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/13.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p14 = new Photo_Infra
            {
                Id = 14,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/14.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/14.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p15 = new Photo_Infra
            {
                Id = 15,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/15.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/15.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p16 = new Photo_Infra
            {
                Id = 16,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/16.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/16.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p17 = new Photo_Infra
            {
                Id = 17,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/17.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/17.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p18 = new Photo_Infra
            {
                Id = 18,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/18.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/18.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p19 = new Photo_Infra
            {
                Id = 19,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/19.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/19.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p20 = new Photo_Infra
            {
                Id = 20,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/20.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/20.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p21 = new Photo_Infra
            {
                Id = 21,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/21.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/21.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p22 = new Photo_Infra
            {
                Id = 22,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/22.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/22.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p23 = new Photo_Infra
            {
                Id = 23,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/23.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/23.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p24 = new Photo_Infra
            {
                Id = 24,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/24.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/24.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p25 = new Photo_Infra
            {
                Id = 25,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/25.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/25.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p26 = new Photo_Infra
            {
                Id = 26,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/26.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/26.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p27 = new Photo_Infra
            {
                Id = 27,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/27.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/27.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p28 = new Photo_Infra
            {
                Id = 28,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/28.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/28.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p29 = new Photo_Infra
            {
                Id = 29,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/29.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/29.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p30 = new Photo_Infra
            {
                Id = 30,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/30.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/30.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p31 = new Photo_Infra
            {
                Id = 31,
                ImgSrc = "~/Content/1_Minsk_ul_Lojinskaja/31.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/31.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p32 = new Photo_Infra
            {
                Id = 32,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/32.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/32.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p33 = new Photo_Infra
            {
                Id = 33,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/33.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/33.jpg",
                Repareobject_InfraId = 1
            }; Photo_Infra p34 = new Photo_Infra
            {
                Id = 34,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/34.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/34.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p35 = new Photo_Infra
            {
                Id = 35,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/35.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/35.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p36 = new Photo_Infra
            {
                Id = 36,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/36.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/36.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p37 = new Photo_Infra
            {
                Id = 37,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/37.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/37.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p38 = new Photo_Infra
            {
                Id = 38,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/38.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/38.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p39 = new Photo_Infra
            {
                Id = 39,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/39.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/39.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p40 = new Photo_Infra
            {
                Id = 40,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/40.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/40.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p41 = new Photo_Infra
            {
                Id = 41,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/41.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/41.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p42 = new Photo_Infra
            {
                Id = 42,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/42.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/42.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p43 = new Photo_Infra
            {
                Id = 43,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/43.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/43.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p44 = new Photo_Infra
            {
                Id = 44,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/44.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/44.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p45 = new Photo_Infra
            {
                Id = 45,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/45.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/45.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p46 = new Photo_Infra
            {
                Id = 46,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/46.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/46.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p47 = new Photo_Infra
            {
                Id = 47,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/47.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/47.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p48 = new Photo_Infra
            {
                Id = 48,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/48.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/48.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p49 = new Photo_Infra
            {
                Id = 49,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/49.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/49.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p50 = new Photo_Infra
            {
                Id = 50,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/50.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/50.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p51 = new Photo_Infra
            {
                Id = 51,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/51.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/51.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p52 = new Photo_Infra
            {
                Id = 52,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/52.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/52.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p53 = new Photo_Infra
            {
                Id = 53,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/53.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/53.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p54 = new Photo_Infra
            {
                Id = 54,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/54.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/54.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p55 = new Photo_Infra
            {
                Id = 55,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/55.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/55.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p56 = new Photo_Infra
            {
                Id = 56,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/56.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/56.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p57 = new Photo_Infra
            {
                Id = 57,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/57.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/57.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p58 = new Photo_Infra
            {
                Id = 58,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/58.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/58.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p59 = new Photo_Infra
            {
                Id = 59,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/59.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/59.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p60 = new Photo_Infra
            {
                Id = 60,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/60.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/60.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p61 = new Photo_Infra
            {
                Id = 61,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/61.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/61.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p62 = new Photo_Infra
            {
                Id = 62,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/62.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/62.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p63 = new Photo_Infra
            {
                Id = 63,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/63.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/63.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p64 = new Photo_Infra
            {
                Id = 64,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/64.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/64.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p65 = new Photo_Infra
            {
                Id = 65,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/65.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/65.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p67 = new Photo_Infra
            {
                Id = 67,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/67.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/67.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p68 = new Photo_Infra
            {
                Id = 68,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/68.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/68.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p69 = new Photo_Infra
            {
                Id = 69,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/69.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/69.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p70 = new Photo_Infra
            {
                Id = 70,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/70.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/70.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p71 = new Photo_Infra
            {
                Id = 71,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/71.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/71.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p72 = new Photo_Infra
            {
                Id = 72,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/72.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/72.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p73 = new Photo_Infra
            {
                Id = 73,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/73.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/73.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p74 = new Photo_Infra
            {
                Id = 74,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/74.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/74.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p75 = new Photo_Infra
            {
                Id = 75,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/75.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/75.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p76 = new Photo_Infra
            {
                Id = 76,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/76.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/76.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p77 = new Photo_Infra
            {
                Id = 77,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/77.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/77.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p78 = new Photo_Infra
            {
                Id = 78,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/78.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/78.jpg",
                Repareobject_InfraId = 1
            };            
            
            //Фото №79 удалено т.к. дубликат
            Photo_Infra p80 = new Photo_Infra
            {
                Id = 80,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/80.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/80.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p81 = new Photo_Infra
            {
                Id = 81,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/81.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/81.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p82 = new Photo_Infra
            {
                Id = 82,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/82.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/82.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p83 = new Photo_Infra
            {
                Id = 83,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/83.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/83.jpg",
                Repareobject_InfraId = 1
            };
            Photo_Infra p84 = new Photo_Infra
            {
                Id = 84,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/84.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/84.jpg",
                Repareobject_InfraId = 1
            };
            //Фото №85 удалено т.к. дубликат
            Photo_Infra p86 = new Photo_Infra
            {
                Id = 86,
                ImgSrc = "/Content/1_Minsk_ul_Lojinskaja/86.jpg",
                ImgSrcMini = "/Content/1_Minsk_ul_Lojinskaja/mini/86.jpg",
                Repareobject_InfraId = 1
            };
            #endregion

            //Обьект ремонта - "Минский р-н, д.Копище, ул.Подгорная"
            #region
            Photo_Infra p87 = new Photo_Infra
            {
                Id = 87,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/1.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/1.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p88 = new Photo_Infra
            {
                Id = 88,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/2.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/2.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p89 = new Photo_Infra
            {
                Id = 89,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/3.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/3.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p90 = new Photo_Infra
            {
                Id = 90,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/4.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/4.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p91 = new Photo_Infra
            {
                Id = 91,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/5.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/5.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p92 = new Photo_Infra
            {
                Id = 92,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/6.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/6.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p93 = new Photo_Infra
            {
                Id = 93,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/7.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/7.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p94 = new Photo_Infra
            {
                Id = 94,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/8.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/8.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p95 = new Photo_Infra
            {
                Id = 95,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/9.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/9.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p96 = new Photo_Infra
            {
                Id = 96,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/10.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/10.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p97 = new Photo_Infra
            {
                Id = 97,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/11.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/11.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p98 = new Photo_Infra
            {
                Id = 98,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/12.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/12.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p99 = new Photo_Infra
            {
                Id = 99,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/13.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/13.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p100 = new Photo_Infra
            {
                Id = 100,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/14.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/14.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p101 = new Photo_Infra
            {
                Id = 101,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/15.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/15.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p102 = new Photo_Infra
            {
                Id = 102,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/16.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/16.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p103 = new Photo_Infra
            {
                Id = 103,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/17.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/17.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p104 = new Photo_Infra
            {
                Id = 104,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/18.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/18.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p105 = new Photo_Infra
            {
                Id = 105,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/19.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/19.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p106 = new Photo_Infra
            {
                Id = 106,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/20.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/20.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p107 = new Photo_Infra
            {
                Id = 107,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/21.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/21.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p108 = new Photo_Infra
            {
                Id = 108,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/22.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/22.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p109 = new Photo_Infra
            {
                Id = 109,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/23.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/23.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p110 = new Photo_Infra
            {
                Id = 110,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/24.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/24.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p111 = new Photo_Infra
            {
                Id = 111,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/25.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/25.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p112 = new Photo_Infra
            {
                Id = 112,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/26.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/26.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p113 = new Photo_Infra
            {
                Id = 113,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/27.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/27.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p114 = new Photo_Infra
            {
                Id = 114,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/28.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/28.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p115 = new Photo_Infra
            {
                Id = 115,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/29.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/29.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p116 = new Photo_Infra
            {
                Id = 116,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/30.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/30.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p117 = new Photo_Infra
            {
                Id = 117,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/31.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/31.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p118 = new Photo_Infra
            {
                Id = 118,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/32.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/32.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p119 = new Photo_Infra
            {
                Id = 119,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/33.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/33.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p120 = new Photo_Infra
            {
                Id = 120,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/34.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/34.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p121 = new Photo_Infra
            {
                Id = 121,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/35.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/35.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p122 = new Photo_Infra
            {
                Id = 122,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/36.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/36.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p123 = new Photo_Infra
            {
                Id = 123,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/37.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/37.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p124 = new Photo_Infra
            {
                Id = 124,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/38.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/38.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p125 = new Photo_Infra
            {
                Id = 125,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/39.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/39.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p126 = new Photo_Infra
            {
                Id = 126,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/40.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/40.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p127 = new Photo_Infra
            {
                Id =127,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/41.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/41.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p128 = new Photo_Infra
            {
                Id = 128,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/42.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/42.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p129 = new Photo_Infra
            {
                Id = 129,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/43.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/43.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p130 = new Photo_Infra
            {
                Id = 130,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/44.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/44.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p131 = new Photo_Infra
            {
                Id = 131,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/45.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/45.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p132 = new Photo_Infra
            {
                Id = 132,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/46.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/46.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p133 = new Photo_Infra
            {
                Id = 133,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/47.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/47.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p134 = new Photo_Infra
            {
                Id = 134,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/48.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/48.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p135 = new Photo_Infra
            {
                Id = 135,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/49.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/49.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p136 = new Photo_Infra
            {
                Id = 136,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/50.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/50.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p137 = new Photo_Infra
            {
                Id = 137,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/51.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/51.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p138 = new Photo_Infra
            {
                Id = 138,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/52.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/52.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p139 = new Photo_Infra
            {
                Id = 139,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/53.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/53.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p140 = new Photo_Infra
            {
                Id = 140,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/54.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/54.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p141 = new Photo_Infra
            {
                Id = 141,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/55.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/55.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p142 = new Photo_Infra
            {
                Id = 142,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/56.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/56.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p143 = new Photo_Infra
            {
                Id = 143,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/57.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/57.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p144 = new Photo_Infra
            {
                Id = 144,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/58.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/58.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p145 = new Photo_Infra
            {
                Id = 145,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/59.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/59.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p146 = new Photo_Infra
            {
                Id = 146,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/60.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/60.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p147 = new Photo_Infra
            {
                Id = 147,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/61.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/61.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p148 = new Photo_Infra
            {
                Id = 148,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/62.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/62.jpg",
                Repareobject_InfraId = 2
            };
            //фото №63 и связанная с ним сущность удалена(качество плохое)
            Photo_Infra p150 = new Photo_Infra
            {
                Id = 150,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/64.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/64.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p151 = new Photo_Infra
            {
                Id = 151,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/65.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/65.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p152 = new Photo_Infra
            {
                Id = 152,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/66.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/66.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p153 = new Photo_Infra
            {
                Id = 153,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/67.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/67.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p154 = new Photo_Infra
            {
                Id = 154,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/68.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/68.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p155 = new Photo_Infra
            {
                Id = 155,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/69.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/69.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p156 = new Photo_Infra
            {
                Id = 156,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/70.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/70.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p157 = new Photo_Infra
            {
                Id = 157,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/71.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/71.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p158 = new Photo_Infra
            {
                Id = 158,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/72.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/72.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p159 = new Photo_Infra
            {
                Id = 159,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/73.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/73.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p160 = new Photo_Infra
            {
                Id = 160,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/74.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/74.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p161 = new Photo_Infra
            {
                Id = 161,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/75.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/75.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p162 = new Photo_Infra
            {
                Id = 162,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/76.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/76.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p163 = new Photo_Infra
            {
                Id = 163,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/77.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/77.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p164 = new Photo_Infra
            {
                Id = 164,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/78.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/78.jpg",
                Repareobject_InfraId = 2
            };
            //фото №79 и связанная с ним сущность удалена(качество плохое)
            Photo_Infra p166 = new Photo_Infra
            {
                Id = 166,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/80.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/80.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p167 = new Photo_Infra
            {
                Id = 167,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/81.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/81.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p168 = new Photo_Infra
            {
                Id = 168,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/82.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/82.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p169 = new Photo_Infra
            {
                Id = 169,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/83.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/83.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p170 = new Photo_Infra
            {
                Id = 170,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/84.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/84.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p171 = new Photo_Infra
            {
                Id = 171,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/85.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/85.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p172 = new Photo_Infra
            {
                Id = 172,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/86.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/86.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p173 = new Photo_Infra
            {
                Id = 173,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/87.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/87.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p174 = new Photo_Infra
            {
                Id = 174,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/88.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/88.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p175 = new Photo_Infra
            {
                Id = 175,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/89.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/89.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p176 = new Photo_Infra
            {
                Id = 176,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/90.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/90.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p177 = new Photo_Infra
            {
                Id = 177,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/91.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/91.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p178 = new Photo_Infra
            {
                Id = 178,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/92.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/92.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p179 = new Photo_Infra
            {
                Id = 179,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/93.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/93.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p180 = new Photo_Infra
            {
                Id = 180,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/94.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/94.jpg",
                Repareobject_InfraId = 2
            };
            Photo_Infra p181 = new Photo_Infra
            {
                Id = 181,
                ImgSrc = "/Content/2_der_Kopichje_ul_Podgornaya/95.jpg",
                ImgSrcMini = "/Content/2_der_Kopichje_ul_Podgornaya/mini/95.jpg",
                Repareobject_InfraId = 2
            };


            #endregion

            //Обьект ремонта - "Минский р-н, а.г.Сёмково"
            #region
            Photo_Infra p182 = new Photo_Infra
            {
                Id = 182,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/1.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/1.jpg",
                Repareobject_InfraId = 3
            };

            //фото №2 и связанная с ним сущность удалена(качество плохое)

            Photo_Infra p184 = new Photo_Infra
            {
                Id = 184,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/3.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/3.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p185 = new Photo_Infra
            {
                Id = 185,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/4.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/4.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p186 = new Photo_Infra
            {
                Id = 186,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/5.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/5.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p187 = new Photo_Infra
            {
                Id = 187,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/6.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/6.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p188 = new Photo_Infra
            {
                Id = 188,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/7.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/7.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p189 = new Photo_Infra
            {
                Id = 189,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/8.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/8.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p190 = new Photo_Infra
            {
                Id = 190,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/9.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/9.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p191 = new Photo_Infra
            {
                Id = 191,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/10.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/10.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p192 = new Photo_Infra
            {
                Id = 192,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/11.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/11.jpg",
                Repareobject_InfraId = 3
            };
            Photo_Infra p193 = new Photo_Infra
            {
                Id = 193,
                ImgSrc = "/Content/3_reg_Minskij_ag_Semkovo/12.jpg",
                ImgSrcMini = "/Content/3_reg_Minskij_ag_Semkovo/mini/12.jpg",
                Repareobject_InfraId = 3
            };
            #endregion

            //Comment
            #region
            Comment_Infra c1 = new Comment_Infra
            {
                Id = 1,
                UserName = "Стриго Виктория",
                MessageFromUser = "Отличное качество выполненных работ! Специалисты отработали без нареканий и в срок.",
                ApprovalForPublishing = true
            };
            #endregion

            //CallMee
            #region
            CallMee_Infra cm1 = new CallMee_Infra
            {
                Id = 1,
                Name = "Тестовый пользователь",
                DateStamp = new System.DateTime(2019, 9, 24),
                Telephone = "+375 44 752 82 63",
                Comments = "Комментарий к обратному звонку",
                CallIsDone = true

            };
            #endregion

            //Stage
            #region
            Stage_Infra s1 = new Stage_Infra
            {
                Id = 1,
                ImgSrc = "/Content/Icon/Stage/Stage_1.png",
                DescriptionOfStage = "Консультация по телефону, либо онлайн"
            };
            Stage_Infra s2 = new Stage_Infra
            {
                Id = 2,
                ImgSrc = "/Content/Icon/Stage/Stage_2.png",
                DescriptionOfStage = "Выезд на объект, замер"
            };
            Stage_Infra s3 = new Stage_Infra
            {
                Id = 3,
                ImgSrc = "/Content/Icon/Stage/Stage_3.png",
                DescriptionOfStage = "Составление сметы, заключение договора"
            };
            Stage_Infra s4 = new Stage_Infra
            {
                Id = 4,
                ImgSrc = "/Content/Icon/Stage/Stage_4.png",
                DescriptionOfStage = "Выполнение ремонтных работ согласно договору"
            };
            Stage_Infra s5 = new Stage_Infra
            {
                Id = 5,
                ImgSrc = "/Content/Icon/Stage/Stage_5.png",
                DescriptionOfStage = "Составление акта выполненных работ"
            };
            Stage_Infra s6 = new Stage_Infra
            {
                Id = 6,
                ImgSrc = "/Content/Icon/Stage/Stage_6.png",
                DescriptionOfStage = "Передача готового объекта заказчику"
            };

            #endregion


            #region
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

            modelBuilder.Entity<Photo_Infra>().HasData(p1, p2, p3, p4, p5, p6, p7, p8, p9, p10, p11, p12, p13, p14, p15, p16, p17, p18, p19, p20,
                                                     p21, p22, p23, p24, p25, p26, p27, p28, p29, p30, p31, p32, p33, p34, p35, p36, p37, p38, p39, p40,
                                                     p41, p42, p43, p44, p45, p46, p47, p48, p49, p50, p51, p52, p53, p54, p55, p56, p57, p58, p59, p60,
                                                     p61, p62, p63, p64, p65, p67, p68, p69, p70, p71, p72, p73, p74, p75, p76, p77, p78, p80,
                                                     p81, p82, p83, p84, p86, p87, p88, p89, p90, p91, p92, p93, p94, p95, p96, p97, p98, p99, p100,
                                                     p101, p102, p103, p104, p105, p106, p107, p108, p109, p110, p111, p112, p113, p114, p115, p116, p117, p118, p119, p120,
                                                     p121, p122, p123, p124, p125, p126, p127, p128, p129, p130, p131, p132, p133, p134, p135, p136, p137, p138, p139, p140,
                                                     p141, p142, p143, p144, p145, p146, p147, p148, p150, p151, p152, p153, p154, p155, p156, p157, p158, p159, p160,
                                                     p161, p162, p163, p164, p166, p167, p168, p169, p170, p171, p172, p173, p174, p175, p176, p177, p178, p179, p180,
                                                     p181, p182, p184, p185, p186, p187, p188, p189, p190, p191, p192, p193);
            modelBuilder.Entity<Repareobject_Infra>().HasData(o1, o2, o3);

            modelBuilder.Entity<TypeOfObject_Infra>().HasData(t1, t2, t3, t4, t5, t6, t7);

            modelBuilder.Entity<UnitOfJob_Infra>().HasData(u1, u2, u3);

            modelBuilder.Entity<Comment_Infra>().HasData(c1);

            modelBuilder.Entity<CallMee_Infra>().HasData(cm1);

            modelBuilder.Entity<Stage_Infra>().HasData(s1, s2, s3, s4, s5, s6);

            modelBuilder.ApplyConfiguration<Job_Infra>(new Job_Configuration());

            modelBuilder.ApplyConfiguration<KindOfJob_Infra>(new Kind_Configuration());

            modelBuilder.ApplyConfiguration<TypeOfObject_Infra>(new Type_Configuration());

            modelBuilder.ApplyConfiguration<UnitOfJob_Infra>(new Unit_Configuration());

            modelBuilder.ApplyConfiguration<Repareobject_Infra>(new Repareobject_Configuration());

            modelBuilder.ApplyConfiguration<Photo_Infra>(new Photo_Configuration());

            modelBuilder.ApplyConfiguration<Stage_Infra>(new Stage_Configuration());

            modelBuilder.ApplyConfiguration<Comment_Infra>(new Comment_Configuration());

            modelBuilder.ApplyConfiguration<CallMee_Infra>(new CallMee_Configuration());

            base.OnModelCreating(modelBuilder);
            #endregion
        }
    }
}