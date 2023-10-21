using System;
using BSIT3L_Movies.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSIT3L_Movies.Controllers
{
    public class MoviesController : Controller
    {
        private List<MovieViewModel> _movies;
        public MoviesController()
        {
            // Sample movie data
            _movies = new List<MovieViewModel>
            {
            new MovieViewModel { Id = 1, Name = "Shrek", Rating = "5", ReleaseYear = 2001, Genre = "Commedy/Action",
                MovieDetails = "Once upon a time, in a far away swamp, there lived an ogre named Shrek whose precious solitude is suddenly shattered by an invasion of annoying fairy tale characters. They were all banished from their kingdom by the evil Lord Farquaad. Determined to save their home -- not to mention his -- Shrek cuts a deal with Farquaad and sets out to rescue Princess Fiona to be Farquaad's bride. Rescuing the Princess may be small compared to her deep, dark secret.",
                image = "/Image/shrek.jpg", trailer = "https://www.youtube.com/embed/CwXOrWvPBPk"},
            new MovieViewModel { Id = 2, Name = "Alita: Battle Angel", Rating = "5", ReleaseYear = 2019, Genre = "Sci-Fi/Action",
                MovieDetails = "A deactivated cyborg's revived, but can't remember anything of her past and goes on a quest to find out who she is.",
                image = "/Image/alita.jpg", trailer = "https://www.youtube.com/embed/w7pYhpJaJW8"},
            new MovieViewModel { Id = 3, Name = "Transformers: Rise of the Beast", Rating = "5", ReleaseYear = 2023, Genre = "Action",
                MovieDetails = "An ancient struggle between two Cybertronian races, the heroic Autobots and the evil Decepticons, comes to Earth, with a clue to the ultimate power held by a teenager.",
                image = "/Image/transformers.jpg", trailer = "https://www.youtube.com/embed/itnqEauWQZM"},
            new MovieViewModel { Id = 4, Name = "Platform", Rating = "5", ReleaseYear = 2019, Genre = "Drama/Thriller",
                MovieDetails = "A slab of food descends floor by floor in a prison. The inmates above eat heartily, leaving those below starving and desperate. A rebellion is imminent.",
                image = "/Image/platform.jpg", trailer = "https://www.youtube.com/embed/RlfooqeZcdY"},
            new MovieViewModel { Id = 5, Name = "Saw", Rating = "5", ReleaseYear = 2004, Genre = "Indie film/Horror",
                MovieDetails = "Two strangers awaken in a room with no recollection of how they got there, and soon discover they're pawns in a deadly game perpetrated by a notorious serial killer.",
                image = "/Image/saw.jpg", trailer = "https://www.youtube.com/embed/S-1QgOMQ-ls"},
            new MovieViewModel { Id = 6, Name = "One Piece: Red", Rating = "4", ReleaseYear = 2022, Genre = "Adventure/Action",
                MovieDetails = "The Straw Hat Pirates leave for the island of Elegia to attend a concert by Uta, a world-famous singer. After Uta performs her first song (\"New Genesis\"), Luffy goes on stage to reunite with her, revealing that the two of them know each other because Uta is the adopted daughter of \"Red-Haired\" Shanks. They met when Shanks was based at Luffy's hometown 12 years ago, but one day he returned from a voyage without her, claiming she had left to pursue a career as a singer.",
                image = "/Image/onepiece.jpg", trailer = "https://www.youtube.com/embed/eU0i7L3cakI"},
            new MovieViewModel { Id = 7, Name = "Dragon Ball Super: Broly", Rating = "5", ReleaseYear = 2018, Genre = "Action/Animation",
                MovieDetails = "Goku and Vegeta encounter Broly, a Saiyan warrior unlike any fighter they've faced before.",
                image = "/Image/dragonball.jpg", trailer = "https://www.youtube.com/embed/FHgm89hKpXU"},
            new MovieViewModel { Id = 8, Name = "The Green Mile", Rating = "5", ReleaseYear = 1999, Genre = "Drama",
                MovieDetails = "A tale set on death row in a Southern jail, where gentle giant John possesses the mysterious power to heal people's ailments. When the lead guard, Paul, recognizes John's gift, he tries to help stave off the condemned man's execution.",
                image = "/Image/greenmile.jgp", trailer = "https://www.youtube.com/embed/Ki4haFrqSrw"},
            new MovieViewModel { Id = 9, Name = "Blue Beetle", Rating = "4", ReleaseYear = 2023, Genre = "Action",
                MovieDetails = "An alien scarab chooses Jaime Reyes to be its symbiotic host, bestowing the recent college graduate with a suit of armor that's capable of extraordinary powers, forever changing his destiny as he becomes the superhero known as Blue Beetle.",
                image = "/Image/bbeetle.jpg", trailer = "https://www.youtube.com/embed/vS3_72Gb-bI"},
            new MovieViewModel { Id = 10, Name = "Suicide Squad", Rating = "4", ReleaseYear = 2016, Genre = "Action",
                MovieDetails = "Supervillains Harley Quinn, Bloodsport, Peacemaker, and a collection of nutty cons at Belle Reve prison join the super-secret, super-shady Task Force X as they are dropped off at the remote, enemy-infused island of Corto Maltese.",
                image = "/Image/suicidesquad.jpg", trailer = "https://www.youtube.com/embed/CmRih_VtVAs"},
            new MovieViewModel { Id = 11, Name = "Ironman 3", Rating = "5", ReleaseYear = 2013, Genre = "Action/Adventure",
                MovieDetails = "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.",
                image = "/Image/ironman.jpg", trailer = "https://www.youtube.com/embed/Ke1Y3P9D0Bc"},
            new MovieViewModel { Id = 12, Name = "Spider-Man: No Way Home", Rating = "5", ReleaseYear = 2022, Genre = "Action",
                MovieDetails = "With Spider-Man's identity now revealed, Peter asks Doctor Strange for help. When a spell goes wrong, dangerous foes from other worlds start to appear, forcing Peter to discover what it truly means to be Spider-Man.",
                image = "/Image/spiderman.jpg", trailer = "https://www.youtube.com/embed/JfVOs4VSpmA"},
            new MovieViewModel { Id = 13, Name = "Interstellar", Rating = "5", ReleaseYear = 2014, Genre = "Sci-Fi/Drama",
                MovieDetails = "When Earth becomes uninhabitable in the future, a farmer and ex-NASA pilot, Joseph Cooper, is tasked to pilot a spacecraft, along with a team of researchers, to find a new planet for humans.",
                image = "/Image/interstellar.jpg", trailer = "https://www.youtube.com/embed/2LqzF5WauAw"},
            new MovieViewModel { Id = 14, Name = "In Time", Rating = "5", ReleaseYear = 2011, Genre = "Sci-Fi/Drama",
                MovieDetails = "In a future where time is money and the wealthy can live forever, Will Salas (Justin Timberlake) is a poor man who rarely has more than a day's worth of life on his time clock. When he saves Henry Hamilton (Matt Bomer) from time thieves, Will receives the gift of a century. However, such a large transaction attracts the attention of the authorities, and when Will is falsely accused of murder, he must go on the run, taking the daughter (Amanda Seyfried) of an incredibly wealthy man with him.",
                image = "/Image/intime.jpg", trailer = "https://www.youtube.com/embed/YRSBiTF3wNw"},
            new MovieViewModel { Id = 15, Name = "Edge of Tomorrow", Rating = "5", ReleaseYear = 2014, Genre = "Action",
                MovieDetails = "When Earth falls under attack from invincible aliens, no military unit in the world is able to beat them. Maj. William Cage (Tom Cruise), an officer who has never seen combat, is assigned to a suicide mission. Killed within moments, Cage finds himself thrown into a time loop, in which he relives the same brutal fight -- and his death -- over and over again. However, Cage's fighting skills improve with each encore, bringing him and a comrade (Emily Blunt) ever closer to defeating the aliens.",
                image = "/Image/edgeoftomorrow.jpg", trailer = "https://www.youtube.com/embed/yUmSVcttXnI"},
        };
        }
        public ActionResult Random()
        {
            var movie = new MovieViewModel() { Name = "Avatar", Rating = "5" };
            return View(movie);
        }
        public ActionResult GetMovie(int id)
        {
            var movie = _movies.Find(m => m.Id == id);
            if (movie == null)
                return NotFound();
            return View(movie);

        }

    }
}

