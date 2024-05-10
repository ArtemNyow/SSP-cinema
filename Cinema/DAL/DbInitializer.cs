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
                    Email = "user@email.com",
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
                    Name = "Наукова фантастика",
                },
                // Матриця
                new Genre
                {
                    Name = "Бойовик",
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
                        context.Genres.Single(g => g.Name == "Наукова фантастика"),
                    },
                    AgeRating = 12,
                    Rating = 8.5,
                    Description = "Після трагічної події два фокусники в Лондоні 1890-х років вступають у битву, щоб створити ідеальну ілюзію, жертвуючи всім, що вони мають, щоб перехитрити один одного.",
                    Duration = 130,
                    ReleaseDate = new DateTime(2006, 1, 1),
                    Trailer = "https://youtu.be/ObGVA1WOqyE?si=6mJUacgwADAEtNam",
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
                new Ticket
                {
                    UserID = context.Users.Include(u => u.Person).Single(u => u.Person.FirstName == "Аркадій" && u.Person.LastName == "Шнайдер").ID,
                    SessionID = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 17, 19, 30, 0)).ID,
                    RowNumber = 4,
                    SeatNumber = 15,
                    Price = context.Sessions.Single(s => s.DateTime == new DateTime(2024, 5, 17, 19, 30, 0)).TicketPrice,
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
