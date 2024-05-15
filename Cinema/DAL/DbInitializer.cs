using Domain.Enums;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public static class DbInitializer
    {
        public static void Initialize(CinemaDbContext context)
        {
            ArgumentNullException.ThrowIfNull(context);

            context.Database.Migrate();

            if (context.Persons.Any())
            {
                return;
            }

            #region Persons
            var persons = new Person[]
            {
                // Втеча з Шоушенка
                // режисер
                new Person
                {
                    FirstName = "Френк",
                    LastName = "Дарабонт",
                },
                // актори
                new Person
                {
                    FirstName = "Тім",
                    LastName = "Роббінс",
                },
                new Person
                {
                    FirstName = "Морган",
                    LastName = "Фріман",
                },
                new Person
                {
                    FirstName = "Боб",
                    LastName = "Гантон",
                },
                // Матриця
                // режисери
                new Person
                {
                    FirstName = "Енді",
                    LastName = "Вачовскі",
                },
                new Person
                {
                    FirstName = "Ларрі",
                    LastName = "Вачовскі",
                },
                // актори
                new Person
                {
                    FirstName = "Кіану",
                    LastName = "Рівз",
                },
                new Person
                {
                    FirstName = "Лоренс",
                    LastName = "Фішберн",
                },
                new Person
                {
                    FirstName = "Керрі-Енн",
                    LastName = "Мосс",
                },
                // Престиж
                // режисер
                new Person
                {
                    FirstName = "Крістофер",
                    LastName = "Нолан",
                },
                // актори
                new Person
                {
                    FirstName = "Х'ю",
                    LastName = "Джекман",
                },
                new Person
                {
                    FirstName = "Крістіан",
                    LastName = "Бейл",
                },
                new Person
                {
                    FirstName = "Скарлетт",
                    LastName = "Йоханссон",
                },
                // Форрест Гамп
                // режисер
                new Person
                {
                    FirstName = "Роберт",
                    LastName = "Земекіс",
                },
                // актори
                new Person
                {
                    FirstName = "Том",
                    LastName = "Генкс",
                },
                new Person
                {
                    FirstName = "Робін",
                    LastName = "Райт",
                },
                new Person
                {
                    FirstName = "Гарі",
                    LastName = "Сініз",
                },
                // Побачення зі сторони третьої
                // режисер Крістафер Нолан
                // актори
                new Person
                {
                    FirstName = "Леонардо",
                    LastName = "ДіКапріо",
                },
                new Person
                {
                    FirstName = "Джозеф",
                    LastName = "Гордон-Левітт",
                },
                new Person
                {
                    FirstName = "Еллен",
                    LastName = "Пейдж",
                },
                // Шоу Трумана
                // режисер
                new Person
                {
                    FirstName = "Пітер",
                    LastName = "Вір",
                },
                // актори
                new Person
                {
                    FirstName = "Джим",
                    LastName = "Керрі",
                },
                new Person
                {
                    FirstName = "Лора",
                    LastName = "Лінні",
                },
                new Person
                {
                    FirstName = "Ед",
                    LastName = "Харріс",
                },
                // Інтерстеллар
                // режисер Крістафер Нолан
                // актори
                new Person
                {
                    FirstName = "Меттью",
                    LastName = "МакКонахі",
                },
                new Person
                {
                    FirstName = "Енн",
                    LastName = "Гетеуей",
                },
                new Person
                {
                    FirstName = "Джессіка",
                    LastName = "Честейн",
                },
                // Джокер
                // режисер
                new Person
                {
                    FirstName = "Тодд",
                    LastName = "Філліпс",
                },
                // актори
                new Person
                {
                    FirstName = "Хоакін",
                    LastName = "Фенікс",
                },
                new Person
                {
                    FirstName = "Роберт",
                    LastName = "Де Ніро",
                },
                new Person
                {
                    FirstName = "Зазі",
                    LastName = "Бітц",
                },
                // Юзери
                new Person
                {
                    FirstName = "Аркадій",
                    LastName = "Шнайдер",
                },
                new Person
                {
                    FirstName = "Лінус",
                    LastName = "Торвальдс",
                },
                new Person
                {
                    FirstName = "Джейн",
                    LastName = "Сміт",
                },
                new Person
                {
                    FirstName = "Майкл",
                    LastName = "Джонсон",
                },
                new Person
                {
                    FirstName = "Емма",
                    LastName = "Девіс",
                },
            };

            foreach (var person in persons)
            {
                context.Persons.Add(person);
            }
            context.SaveChanges();
            #endregion

            #region Users
            var users = new User[]
            {
                new User
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Аркадій" && p.LastName == "Шнайдер").ID,
                    Email = "arkachka.Kakashka@email.com",
                    Role = UserRole.User,
                    // 12345
                    Password = "F6CA925EBBD902804D727AD8ECE34FCC91003ADA2BA83A1D64479FB1658369D225DB2847E35E67BEF9A414E041C76DF1CBF133B3EBF9B557A179F087EE9DC9B3:A0C4006739C1EAE0F7400492F6C00D9214797786163CCCC60C74366E3F0C7AB375087373F63BB046E1C2707D47F4A462A99FFE443620C25D8EFFAC254AAA0334:50000:SHA512",
                },
                new User
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Лінус" && p.LastName == "Торвальдс").ID,
                    Email = "admin@email.com",
                    Role = UserRole.Administrator,
                    // admin
                    Password = "9CFCBF2EE0D06685FF8582C3380D57231CC5308B5CB6517ED58DDE3F5DDC679A04CE3F3E3F97C03D80CF7BD1F7F21397A7600371BC9ED82FD755B7AFE93C2853:5AC3212367A194B120DDEB5C068356D26D7E86F30BBCD1706E71E7B352208400A658CB2D6FF9566C97B240A890437C62773E00F1966A035DBF8F41EAD33E7279:50000:SHA512",
                },
                new User
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Джейн" && p.LastName == "Сміт").ID,
                    Email = "jane.smith@email.com",
                    Role = UserRole.User,
                    // password123
                    Password = "2CF4EB5BCE56C6A7464A6B52708A5E1947E1B659DFAE8F7279AC3E5ED6C52F1DAD4A2C8E1AED48F70E4643DFDEBB5B8DD203B71D127BF615D49D43DA496A6627:92277885A363FF7D29973B7FF84B7F33B3FF8D5AB61895E3A45DAB6C3C23A90C96F2984C36B91C8BF9CFBF5F2D14A9011D9A6351B6441C0B694676CEC2438EF:50000:SHA512",
                },
                new User
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Майкл" && p.LastName == "Джонсон").ID,
                    Email = "michael.johnson@email.com",
                    Role = UserRole.User,
                    // pass1234
                    Password = "514CADBB8E2055F1935A57E533BB8AC08F575F292FA0CF730DEBB3B046A6B0B7F2B11A72E9F2B469EF50AD5E6C5D9E049C8BBB5A4D07981F0DC5F0C65EC1D1E4:60F855C42E8C6A7E76E7A6D63D1B13C4C13E6A21E79DEBB7B91D7E1FCA0DD12E45DE5A19AB0F3E2C7619DEA1D8B9D21A3182043C40B5F478C5940DEE485207E:50000:SHA512",
                },
                new User
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Емма" && p.LastName == "Девіс").ID,
                    Email = "emma.davis@email.com",
                    Role = UserRole.User,
                    // securepassword
                    Password = "B1F8DE938E9B2FFD935E164E7F7C08B9F4909CE2DC0A5D92B61775B73322F76EE06F9735F03E77C08D367C9FC87DA3DEA0EAC88A1AD31B7C6D0A00EB05586973:CD11A9FBB35FB97049D86997F41B4042F7611B1184B20876A9F97961B4513B7F3EC10B27DE3D1682C2E596FCE4C9FED196CB5F454BBC79D8BC9D617E7D4B02D:50000:SHA512",
                }

            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }
            context.SaveChanges();
            #endregion

            #region Actors
            var actors = new Actor[]
            {
                // Втеча з Шоушенка
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Тім" && p.LastName == "Роббінс").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Морган" && p.LastName == "Фріман").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Боб" && p.LastName == "Гантон").ID,
                },
                // Матриця
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Кіану" && p.LastName == "Рівз").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Лоренс" && p.LastName == "Фішберн").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Керрі-Енн" && p.LastName == "Мосс").ID,
                },
                // Престиж
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Х'ю" && p.LastName == "Джекман").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Крістіан" && p.LastName == "Бейл").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Скарлетт" && p.LastName == "Йоханссон").ID,
                },
                // Джокер
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Хоакін" && p.LastName == "Фенікс").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Роберт" && p.LastName == "Де Ніро").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Зазі" && p.LastName == "Бітц").ID,
                },
                // Інтерстеллар
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Меттью" && p.LastName == "МакКонахі").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Енн" && p.LastName == "Гетеуей").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Джессіка" && p.LastName == "Честейн").ID,
                },
                // Форрест Гамп
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Том" &&  p.LastName  == "Генкс").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Робін" && p.LastName == "Райт").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Гарі" && p.LastName == "Сініз").ID,
                },
                // Побачення зі сторони третьої
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName ==   "Леонардо" && p.LastName == "ДіКапріо").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Джозеф" && p.LastName == "Гордон-Левітт").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Еллен" && p.LastName == "Пейдж").ID,
                },
                // Шоу Трумана
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Джим" && p.LastName == "Керрі").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Лора" && p.LastName == "Лінні").ID,
                },
                new Actor
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Ед" && p.LastName == "Харріс").ID,
                },
            };

            foreach (var actor in actors)
            {
                context.Actors.Add(actor);
            }
            context.SaveChanges();
            #endregion

            #region Directors
            var directors = new Director[]
            {
                // Втеча з Шоушенка
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Френк" && p.LastName == "Дарабонт").ID,
                },
                // Матриця
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Енді" && p.LastName == "Вачовскі").ID,
                },
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Ларрі" && p.LastName == "Вачовскі").ID,
                },
                // Престиж
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Крістофер" && p.LastName == "Нолан").ID,
                },
                 // Форрест Гамп
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Роберт" && p.LastName == "Земекіс").ID,
                },
                // Побачення зі сторони третьої
                // режисер Крістафер Нолан
                
                // Шоу Трумана
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Пітер" && p.LastName == "Вір").ID,
                },
                // Інтерстеллар
                // режисер Крістафер Нолан

                // Джокер
                new Director
                {
                    PersonID = context.Persons.Single(p => p.FirstName == "Тодд" && p.LastName == "Філліпс").ID,
                },
            };

            foreach (var director in directors)
            {
                context.Directors.Add(director);
            }
            context.SaveChanges();
            #endregion

            #region Genres
            var genres = new Genre[]
            {
                 // Престиж, Втеча з Шоушенка
                new Genre
                {
                    Name = "Драма",
                },
                // Престиж 
                new Genre
                {
                    Name = "Фільм-таємниця",
                },
                // Престиж
                new Genre
                {
                    Name = "Науково-фантастичний",
                },
                // Матриця
                new Genre
                {
                    Name = "Бойовик",
                },
                // Додані нові жанри
                // Форрест Гамп
                new Genre
                {
                    Name = "Комедія",
                },
                // Побачення зі сторони третьої
                new Genre
                {
                    Name = "Художній",
                },
                // Шоу Трумана
                new Genre
                {
                    Name = "Драмеді",
                },
                // Джокер
                new Genre
                {
                    Name = "Кримінальний",
                },
                // Інтерстеллар
                new Genre
                {
                    Name = "Пригоди",
                },
            };

            foreach (var genre in genres)
            {
                context.Genres.Add(genre);
            }
            context.SaveChanges();
            #endregion

            #region Movies
            var movies = new Movie[]
            {
                // Втеча з Шоушенка
                new Movie
                {
                    Title = "Втеча з Шоушенка",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Тім" && a.Person.LastName == "Роббінс"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Морган" && a.Person.LastName == "Фріман"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Боб" && a.Person.LastName == "Гантон"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Френк" && a.Person.LastName == "Дарабонт"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Драма"),
                    },
                    AgeRating = 16,
                    Rating = 9.3,
                    Description = "Протягом кількох років двоє ув'язнених потоваришували, шукаючи розради і, зрештою, спокути через елементарне співчуття.",
                    Duration = 144,
                    ReleaseDate = new DateTime(1994, 1, 1),
                    Trailer = "https://youtu.be/PLl99DlL6b4?si=5T4538B4Is9XBKHm",
                },
                // Матриця 
                new Movie
                {
                    Title = "Матриця",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Кіану" && a.Person.LastName == "Рівз"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Лоренс" && a.Person.LastName == "Фішберн"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Керрі-Енн" && a.Person.LastName == "Мосс"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Енді" && a.Person.LastName == "Вачовскі"),
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Ларрі" && a.Person.LastName == "Вачовскі"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Бойовик"),
                    },
                    AgeRating = 16,
                    Rating = 8.7,
                    Description = "Коли гарна незнайомка веде комп'ютерного хакера Нео до забороненого злочинного світу, він дізнається про шокуючу правду: життя, яке він знає, є ретельно продуманим обманом злого кіберінтелекту.",
                    Duration = 136,
                    ReleaseDate = new DateTime(1999, 1, 1),
                    Trailer = "https://www.youtube.com/watch?v=m8e-FF8MsqU",
                },
                // Престиж
                new Movie
                {
                    Title = "Престиж",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Х'ю" && a.Person.LastName == "Джекман"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Крістіан" && a.Person.LastName == "Бейл"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Скарлетт" && a.Person.LastName == "Йоханссон"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Крістофер" && a.Person.LastName == "Нолан"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Драма"),
                        context.Genres.Single(g => g.Name == "Фільм-таємниця"),
                        context.Genres.Single(g => g.Name == "Науково-фантастичний"),
                    },
                    AgeRating = 12,
                    Rating = 8.5,
                    Description = "Після трагічної події два фокусники в Лондоні 1890-х років вступають у битву, щоб створити ідеальну ілюзію, жертвуючи всім, що вони мають, щоб перехитрити один одного.",
                    Duration = 130,
                    ReleaseDate = new DateTime(2006, 1, 1),
                    Trailer = "https://youtu.be/ObGVA1WOqyE?si=6mJUacgwADAEtNam",
                },
                // Форрест Гамп
                new Movie
                {
                    Title = "Форрест Гамп",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Том" && a.Person.LastName == "Генкс"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Робін" && a.Person.LastName == "Райт"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Гарі" && a.Person.LastName == "Сініз"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Роберт" && a.Person.LastName == "Земекіс"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Драма"),
                        context.Genres.Single(g => g.Name == "Комедія"),
                    },
                    AgeRating = 12,
                    Rating = 8.8,
                    Description = "Історія життя Форреста Гампа, з кінця 1940-х до початку 1980- х,розповідь про ідеально просту людину,яка живе незвичайним життям.",
                    Duration = 142,
                    ReleaseDate = new DateTime(1994, 7, 6),
                    Trailer = "https://youtu.be/8eYHtnL1rXw",
                },
                // Побачення зі сторони третьої
                new Movie
                {
                    Title = "Побачення зі сторони третьої",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Леонардо" && a.Person.LastName == "ДіКапріо"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Джозеф" && a.Person.LastName == "Гордон-Левітт"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Еллен" && a.Person.LastName == "Пейдж"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Крістофер" && a.Person.LastName == "Нолан"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Художній"),
                    },
                    AgeRating = 16,
                    Rating = 8.8,
                    Description = "Домовленості двох людей випробовуються в ході планування великої корпоративної шахрайської схеми.",
                    Duration = 148,
                    ReleaseDate = new DateTime(2010, 7, 16),
                    Trailer = "https://youtu.be/2_4Hi1F8kZ8",
                },
                // Джокер
                new Movie
                {
                    Title = "Джокер",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Хоакін" && a.Person.LastName == "Фенікс"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Роберт" && a.Person.LastName == "Де Ніро"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Зазі" && a.Person.LastName == "Бітц"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Тодд" && a.Person.LastName == "Філліпс"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Кримінальний"),
                    },
                    AgeRating = 18,
                    Rating = 8.6,
                    Description = "У 1981 році нещасливий комік Артур Флек співпрацює зі злочинними й вчиняє повстання й стає відомий як Джокер.",
                    Duration = 122,
                    ReleaseDate = new DateTime(2019, 10, 4),
                    Trailer = "https://www.youtube.com/watch?v=zAGVQLHvwOY",
                },
                // Інтерстеллар
                new Movie
                {
                    Title = "Інтерстеллар",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Меттью" && a.Person.LastName == "МакКонахі"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Енн" && a.Person.LastName == "Гетеуей"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Джессіка" && a.Person.LastName == "Честейн"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Крістофер" && a.Person.LastName == "Нолан"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Художній"),
                        context.Genres.Single(g => g.Name == "Науково-фантастичний"),
                        context.Genres.Single(g => g.Name == "Пригоди"),
                    },
                    AgeRating = 12,
                    Rating = 8.6,
                    Description = "Земля випробовується глобальними катастрофами, і команда дослідників вирушає у космос, щоб знайти нове місце для  життя людей.",
                    Duration = 169,
                    ReleaseDate = new DateTime(2014, 11, 7),
                    Trailer = "https://youtu.be/0vxOhd4qlnA",
                },
                // Шоу Трумана
                new Movie
                {
                    Title = "Шоу Трумана",
                    Actors = new List<Actor>
                    {
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Джим" && a.Person.LastName == "Керрі"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Лора" && a.Person.LastName == "Лінні"),
                        context.Actors.Include(a => a.Person).Single(a => a.Person.FirstName == "Ед" && a.Person.LastName == "Харріс"),
                    },
                    Directors = new List<Director>
                    {
                        context.Directors.Include(a => a.Person).Single(a => a.Person.FirstName == "Пітер" && a.Person.LastName == "Вір"),
                    },
                    Genres = new List<Genre>
                    {
                        context.Genres.Single(g => g.Name == "Художній"),
                        context.Genres.Single(g => g.Name == "Драма"),
                        context.Genres.Single(g => g.Name == "Науково-фантастичний"),
                    },
                    AgeRating = 12,
                    Rating = 8.1,
                    Description = "Життя чоловіка, яке повністю транслюється у прямому ефірі національного телеканалу, виявляється справжнім лицем американської медіа-культури.",
                    Duration = 103,
                    ReleaseDate = new DateTime(1998, 6, 5),
                    Trailer = "https://youtu.be/YKdewAWRRGI",
                },

            };

            foreach (var movie in movies)
            {
                context.Movies.Add(movie);
            }
            context.SaveChanges();
            #endregion

            #region Halls
            var halls = new Hall[]
            {
                new Hall
                {
                    Number = 1,
                    RowsCount = 10,
                    SeatsCountPerRow = 20,
                    RowsVipCount = 0,
                    SeatsVipCountPerRow = 0,
                },
                new Hall
                {
                    Number = 2,
                    RowsCount = 7,
                    SeatsCountPerRow = 12,
                    RowsVipCount = 0,
                    SeatsVipCountPerRow = 0,
                },
                new Hall
                {
                    Number = 3,
                    RowsCount = 9,
                    SeatsCountPerRow = 22,
                    RowsVipCount = 1,
                    SeatsVipCountPerRow = 18,
                },
                new Hall
                {
                    Number = 4,
                    RowsCount = 8,
                    SeatsCountPerRow = 16,
                    RowsVipCount = 0,
                    SeatsVipCountPerRow = 0,
                },
                new Hall
                {
                    Number = 5,
                    RowsCount = 6,
                    SeatsCountPerRow = 10,
                    RowsVipCount = 0,
                    SeatsVipCountPerRow = 0,
                },
                new Hall
                {
                    Number = 6,
                    RowsCount = 11,
                    SeatsCountPerRow = 24,
                    RowsVipCount = 2,
                    SeatsVipCountPerRow = 20,
                },
            };

            foreach (var hall in halls)
            {
                context.Halls.Add(hall);
            }
            context.SaveChanges();
            #endregion

            #region Sessions
            var sessions = new Session[]
            {
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 1).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Втеча з Шоушенка").ID,
                    DateTime = new DateTime(2024, 5, 15, 14, 30, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 190,
                    TicketVipPrice = 0,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 1).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Втеча з Шоушенка").ID,
                    DateTime = new DateTime(2024, 5, 4, 16, 0, 0),
                    Status = SessionStatus.Archived,
                    TicketPrice = 150,
                    TicketVipPrice = 0,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 2).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Матриця").ID,
                    DateTime = new DateTime(2024, 5, 17, 19, 30, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 220,
                    TicketVipPrice = 0,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 3).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Престиж").ID,
                    DateTime = new DateTime(2024, 5, 20, 20, 0, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 190,
                    TicketVipPrice = 290,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 4).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Форрест Гамп").ID,
                    DateTime = new DateTime(2024, 5, 25, 15, 45, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 200,
                    TicketVipPrice = 0,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 5).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Побачення зі сторони третьої").ID,
                    DateTime = new DateTime(2024, 5, 28, 17, 30, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 180,
                    TicketVipPrice = 0,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 6).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Шоу Трумана").ID,
                    DateTime = new DateTime(2024, 5, 22, 18, 15, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 210,
                    TicketVipPrice = 0,
                },
                new Session
                {
                    HallID = context.Halls.Single(h => h.Number == 6).ID,
                    MovieID = context.Movies.Single(m => m.Title == "Інтерстеллар").ID,
                    DateTime = new DateTime(2024, 5, 30, 20, 0, 0),
                    Status = SessionStatus.Active,
                    TicketPrice = 240,
                    TicketVipPrice = 350,
                },
            };

            foreach (var session in sessions)
            {
                context.Sessions.Add(session);
            }
            context.SaveChanges();
            #endregion

            #region Tickets
            var tickets = new Ticket[]
            {
                // Квитки для користувача Аркадія Шнайдера
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Аркадій" && u.Person.LastName == "Шнайдер").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 17, 19, 30, 0)).ID,
                    RowNumber = 4,
                    SeatNumber = 15,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 17, 19, 30, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Аркадій" && u.Person.LastName == "Шнайдер").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 20, 20, 0, 0)).ID,
                    RowNumber = 7,
                    SeatNumber = 10,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 20, 20, 0, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Аркадій" &&  u.Person.LastName == "Шнайдер").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 22, 18, 15, 0)).ID,
                    RowNumber = 9,
                    SeatNumber = 5,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 22, 18, 15, 0)).TicketPrice,
                },
                
                // Квитки для користувача Лінуса Торвальдса
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Лінус" && u.Person.LastName == "Торвальдс").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 17, 19, 30, 0)).ID,
                    RowNumber = 5,
                    SeatNumber = 12,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 17, 19, 30, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Лінус" && u.Person.LastName == "Торвальдс").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 25, 15, 45, 0)).ID,
                    RowNumber = 3,
                    SeatNumber = 8,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 25, 15, 45, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Лінус" && u.Person.LastName == "Торвальдс").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 30, 20, 0, 0)).ID,
                    RowNumber = 6,
                    SeatNumber = 14,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime (2024, 5, 30, 20, 0, 0)).TicketPrice,
                },
                // Квитки для відвідувача Джейн Сміт
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Джейн" && u.Person.LastName == "Сміт").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 4, 16, 0, 0)).ID,
                    RowNumber = 5,
                    SeatNumber = 10,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 4, 16, 0, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Джейн" && u.Person.LastName == "Сміт").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 15, 14, 30, 0)).ID,
                    RowNumber = 2,
                    SeatNumber = 5,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 15, 14, 30, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Джейн" && u.Person.LastName == "Сміт").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 20, 20, 0, 0)).ID,
                    RowNumber = 6,
                    SeatNumber = 12,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 20, 20, 0, 0)).TicketPrice,
                },
                // Квитки для відвідувача Майкл Джонсон
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Майкл" && u.Person.LastName == "Джонсон").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 15, 14, 30, 0)).ID,
                    RowNumber = 3,
                    SeatNumber = 8,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 15, 14, 30, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Майкл" && u.Person.LastName == "Джонсон").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 20, 20, 0, 0)).ID,
                    RowNumber = 4,
                    SeatNumber = 17,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 20, 20, 0, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Майкл" && u.Person.LastName == "Джонсон").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 22, 18, 15, 0)).ID,
                    RowNumber = 8,
                    SeatNumber = 20,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 22, 18, 15, 0)).TicketPrice,
                },
                // Квитки для Емми Девіс
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Емма" && u.Person.LastName == "Девіс").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 17, 19, 30, 0)).ID,
                    RowNumber = 5,
                    SeatNumber = 12,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 17, 19, 30, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Емма" && u.Person.LastName == "Девіс").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 25, 15, 45, 0)).ID,
                    RowNumber = 2,
                    SeatNumber = 7,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 25, 15, 45, 0)).TicketPrice,
                },
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Емма" && u.Person.LastName == "Девіс").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 30, 20, 0, 0)).ID,
                    RowNumber = 7,
                    SeatNumber = 18,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 30, 20, 0, 0)).TicketPrice,
                },
            };

            foreach (var ticket in tickets)
            {
                context.Tickets.Add(ticket);
            }
            context.SaveChanges();
            #endregion
        }
    }
}
