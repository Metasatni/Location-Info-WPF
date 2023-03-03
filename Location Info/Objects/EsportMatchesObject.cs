using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_Info.Objects
{
    public class EsportMatchesObject
    {
        public class Game
        {
            [JsonProperty("begin_at")]
            public DateTime? BeginAt { get; set; }

            [JsonProperty("complete")]
            public bool Complete { get; set; }

            [JsonProperty("detailed_stats")]
            public bool DetailedStats { get; set; }

            [JsonProperty("end_at")]
            public DateTime? EndAt { get; set; }

            [JsonProperty("finished")]
            public bool Finished { get; set; }

            [JsonProperty("forfeit")]
            public bool Forfeit { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("length")]
            public int? Length { get; set; }

            [JsonProperty("match_id")]
            public int MatchId { get; set; }

            [JsonProperty("position")]
            public int Position { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("winner")]
            public Winner Winner { get; set; }

            [JsonProperty("winner_type")]
            public string WinnerType { get; set; }
        }

        public class League
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("image_url")]
            public object ImageUrl { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("url")]
            public string Url { get; set; }
        }

        public class Live
        {
            [JsonProperty("opens_at")]
            public object OpensAt { get; set; }

            [JsonProperty("supported")]
            public bool Supported { get; set; }

            [JsonProperty("url")]
            public object Url { get; set; }
        }

        public class Opponent
        {
            [JsonProperty("opponent")]
            public Opponent2 Opponents { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }
        }

        public class Opponent2
        {
            [JsonProperty("acronym")]
            public object Acronym { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

        public class Result
        {
            [JsonProperty("score")]
            public int Score { get; set; }

            [JsonProperty("team_id")]
            public int TeamId { get; set; }
        }

        public class EsportMatchesRoot
        {
            [JsonProperty("begin_at")]
            public DateTime BeginAt { get; set; }

            [JsonProperty("detailed_stats")]
            public bool DetailedStats { get; set; }

            [JsonProperty("draw")]
            public bool Draw { get; set; }

            [JsonProperty("end_at")]
            public DateTime? EndAt { get; set; }

            [JsonProperty("forfeit")]
            public bool Forfeit { get; set; }

            [JsonProperty("game_advantage")]
            public object GameAdvantage { get; set; }

            [JsonProperty("games")]
            public List<Game> Games { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("league")]
            public League League { get; set; }

            [JsonProperty("league_id")]
            public int LeagueId { get; set; }

            [JsonProperty("live")]
            public Live Live { get; set; }

            [JsonProperty("match_type")]
            public string MatchType { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("number_of_games")]
            public int NumberOfGames { get; set; }

            [JsonProperty("opponents")]
            public List<Opponent> Opponents { get; set; }

            [JsonProperty("original_scheduled_at")]
            public DateTime OriginalScheduledAt { get; set; }

            [JsonProperty("rescheduled")]
            public bool Rescheduled { get; set; }

            [JsonProperty("results")]
            public List<Result> Results { get; set; }

            [JsonProperty("scheduled_at")]
            public DateTime ScheduledAt { get; set; }

            [JsonProperty("serie")]
            public Serie Serie { get; set; }

            [JsonProperty("serie_id")]
            public int SerieId { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("status")]
            public string Status { get; set; }

            [JsonProperty("streams_list")]
            public List<StreamsList> StreamsList { get; set; }

            [JsonProperty("tournament")]
            public Tournament Tournament { get; set; }

            [JsonProperty("tournament_id")]
            public int TournamentId { get; set; }

            [JsonProperty("videogame")]
            public Videogame Videogame { get; set; }

            [JsonProperty("videogame_version")]
            public object VideogameVersion { get; set; }

            [JsonProperty("winner")]
            public Winner Winner { get; set; }

            [JsonProperty("winner_id")]
            public int? WinnerId { get; set; }

            [JsonProperty("winner_type")]
            public string WinnerType { get; set; }
        }

        public class Serie
        {
            [JsonProperty("begin_at")]
            public DateTime BeginAt { get; set; }

            [JsonProperty("end_at")]
            public DateTime? EndAt { get; set; }

            [JsonProperty("full_name")]
            public string FullName { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("league_id")]
            public int LeagueId { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("season")]
            public string Season { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("winner_id")]
            public object WinnerId { get; set; }

            [JsonProperty("winner_type")]
            public object WinnerType { get; set; }

            [JsonProperty("year")]
            public int Year { get; set; }
        }

        public class StreamsList
        {
            [JsonProperty("embed_url")]
            public string EmbedUrl { get; set; }

            [JsonProperty("language")]
            public string Language { get; set; }

            [JsonProperty("main")]
            public bool Main { get; set; }

            [JsonProperty("official")]
            public bool Official { get; set; }

            [JsonProperty("raw_url")]
            public string RawUrl { get; set; }
        }

        public class Tournament
        {
            [JsonProperty("begin_at")]
            public DateTime BeginAt { get; set; }

            [JsonProperty("end_at")]
            public DateTime? EndAt { get; set; }

            [JsonProperty("has_bracket")]
            public bool HasBracket { get; set; }

            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("league_id")]
            public int LeagueId { get; set; }

            [JsonProperty("live_supported")]
            public bool LiveSupported { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("prizepool")]
            public object Prizepool { get; set; }

            [JsonProperty("serie_id")]
            public int SerieId { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }

            [JsonProperty("tier")]
            public string Tier { get; set; }

            [JsonProperty("winner_id")]
            public object WinnerId { get; set; }

            [JsonProperty("winner_type")]
            public string WinnerType { get; set; }
        }

        public class Videogame
        {
            [JsonProperty("id")]
            public int Id { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }

        public class Winner
        {
            [JsonProperty("id")]
            public int? Id { get; set; }

            [JsonProperty("type")]
            public string Type { get; set; }

            [JsonProperty("acronym")]
            public object Acronym { get; set; }

            [JsonProperty("image_url")]
            public string ImageUrl { get; set; }

            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("modified_at")]
            public DateTime ModifiedAt { get; set; }

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("slug")]
            public string Slug { get; set; }
        }


    }
}
