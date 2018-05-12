using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Wicket.Models
{
    public class Meta
    {
        public int upcomingMatchCount { get; set; }
        public int inProgressMatchCount { get; set; }
        public int completedMatchCount { get; set; }
    }

    public class Series
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string shieldImageUrl { get; set; }
        public string seriesUrl { get; set; }
        public bool isDrinksNotificationEnabled { get; set; }
    }

    public class Venue
    {
        public string name { get; set; }
        public string location { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string antisocialPhoneNumber { get; set; }
    }

    public class HomeTeam
    {
        public bool isBatting { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string logoUrl { get; set; }
        public string teamColour { get; set; }
    }

    public class AwayTeam
    {
        public bool isBatting { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string logoUrl { get; set; }
        public string teamColour { get; set; }
        public string backgroundImageUrl { get; set; }
    }

    public class Scores
    {
        public string homeScore { get; set; }
        public string homeOvers { get; set; }
        public string awayScore { get; set; }
        public string awayOvers { get; set; }
    }

    public class MatchWrapArticle
    {
        public string id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public DateTime createdDate { get; set; }
        public string image { get; set; }
        public string url { get; set; }
        public bool hasVideo { get; set; }
        public DateTime publishDate { get; set; }
        public bool isMatchPreview { get; set; }
        public bool isMatchWrap { get; set; }
        public string summaryText { get; set; }
    }

    public class Match
    {
        public int id { get; set; }
        public int matchTypeId { get; set; }
        public int fixturePriority { get; set; }
        public string statisticsProvider { get; set; }
        public Series series { get; set; }
        public string name { get; set; }
        public string status { get; set; }
        public Venue venue { get; set; }
        public HomeTeam homeTeam { get; set; }
        public AwayTeam awayTeam { get; set; }
        public string currentMatchState { get; set; }
        public bool isMultiDay { get; set; }
        public string matchSummaryText { get; set; }
        public Scores scores { get; set; }
        public string twitterHandle { get; set; }
        public string ticketUrl { get; set; }
        public string socialEventId { get; set; }
        public List<object> radioStreams { get; set; }
        public List<object> televisionStreams { get; set; }
        public List<object> relatedVideos { get; set; }
        public List<object> liveStreams { get; set; }
        public bool isFeatured { get; set; }
        public bool isLive { get; set; }
        public int currentInningId { get; set; }
        public bool isRadioStreamActive { get; set; }
        public bool isTvStreamActive { get; set; }
        public bool isMatchDrawn { get; set; }
        public bool isMatchAbandoned { get; set; }
        public DateTime startDateTime { get; set; }
        public DateTime endDateTime { get; set; }
        public string localStartDate { get; set; }
        public string localStartTime { get; set; }
        public bool viewerVerdict { get; set; }
        public bool isTuneInEnabled { get; set; }
        public bool isWomensMatch { get; set; }
        public bool isVideoReplaysAvailable { get; set; }
        public string cmsMatchType { get; set; }
        public string cmsMatchAssociatedType { get; set; }
        public string cmsMatchVenueStartDateTime { get; set; }
        public string cmsMatchVenueEndDateTime { get; set; }
        public string cmsMatchStartDate { get; set; }
        public string cmsMatchEndDate { get; set; }
        public string gamedayStatus { get; set; }
        public bool isGamedayEnabled { get; set; }
        public bool removeMatch { get; set; }
        public MatchWrapArticle matchWrapArticle { get; set; }
    }

    public class MatchList
    {
        public List<Match> matches { get; set; }
    }

    public class RootObject
    {
        public Meta meta { get; set; }
        public MatchList matchList { get; set; }
    }
}