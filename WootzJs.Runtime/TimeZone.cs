using System.Collections.Generic;
using System.Runtime.WootzJs;

namespace System
{
    /// <summary>
    /// Port of Jon Nylander's script is used to calculate current timezone:
    /// https://bitbucket.org/pellepim/jstimezonedetect/src/f9e3e30e1e1f53dd27cd0f73eb51a7e7caf7b378/jstz.js?at=default
    /// </summary>
    public class TimeZone
    {
        private static TimeZone currentTimeZone;

        public static TimeZone CurrentTimeZone
        {
            get
            {
                if (currentTimeZone == null)
                {
                    currentTimeZone = FindCurrentTimezone();
                }
                return currentTimeZone;
            }
        } 

        public string StandardName { get; private set; }

        private TimeSpan offset;

        /// <summary>
        /// Returns the local time that corresponds to a specified date and time value.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.DateTime"/> object whose value is the local time that corresponds to <paramref name="time"/>.
        /// </returns>
        /// <param name="time">A Coordinated Universal Time (UTC) time. </param><filterpriority>2</filterpriority>
        public virtual DateTime ToLocalTime(DateTime time)
        {
            if (time.Kind == DateTimeKind.Local)
                return time;

            return time.Add(offset);
        }

        private const string HEMISPHERE_SOUTH = "s";

        /// <summary>
        /// Gets the offset in minutes from UTC for a certain date.
        /// </summary>
        private static int GetDateOffset(JsDate date) {
            var offset = -date.getTimezoneOffset();
            return offset;
        }

        private static JsDate GetDate(int? year, int month, int date) 
        {
            var d = new JsDate();
            if (year != null) {
                d.setFullYear(year.Value);
            }
            d.setMonth(month);
            d.setDate(date);
            return d;
        }

        private static int GetJanuaryOffset(int? year = null) 
        {
            return GetDateOffset(GetDate(year, 0 ,2));
        }

        private static int GetJuneOffset(int? year = null) 
        {
            return GetDateOffset(GetDate(year, 5, 2));
        }

        /// <summary>
        /// Checks whether a given date is in daylight saving time.
        /// If the date supplied is after august, we assume that we're checking
        /// for southern hemisphere DST.
        /// </summary>
        private static bool DateIsDst(JsDate date) 
        {
            var is_southern = date.getMonth() > 7;
            var base_offset = is_southern ? GetJuneOffset(date.getFullYear()) : GetJanuaryOffset(date.getFullYear());
            var date_offset = GetDateOffset(date);
            var is_west = base_offset < 0;
            var dst_offset = base_offset - date_offset;
                  
            if (!is_west && !is_southern) {
                return dst_offset < 0;
            }

            return dst_offset != 0;
        }

        /// <summary>
        /// This function does some basic calculations to create information about
        /// the user's timezone. It uses REFERENCE_YEAR as a solid year for which
        /// the script has been tested rather than depend on the year set by the
        /// client device.
        ///
        /// 
        /// </summary>
        /// <returns>Returns a key that can be used to do lookups in Timezones. eg: "720,1,2". </returns>
        private static string LookupKey()
        {
            var january_offset = GetJanuaryOffset();
            var june_offset = GetJuneOffset();
            var diff = january_offset - june_offset;

            if (diff < 0) {
                return january_offset + ",1";
            } else if (diff > 0) {
                return june_offset + ",1," + HEMISPHERE_SOUTH;
            }

            return january_offset + ",0";
        }

        private static JsDate ru_pre_dst_change = new JsDate(2010, 6, 15, 1, 0, 0, 0); // In 2010 Russia had DST, this allows us to detect Russia :)
        private static Dictionary<string, JsDate> dstStarts = new Dictionary<string, JsDate> 
        {
            { "America/Denver",  new JsDate(2011, 2, 13, 3, 0, 0, 0) },
            { "America/Mazatlan",  new JsDate(2011, 3, 3, 3, 0, 0, 0) },
            { "America/Chicago",  new JsDate(2011, 2, 13, 3, 0, 0, 0) },
            { "America/Mexico_City",  new JsDate(2011, 3, 3, 3, 0, 0, 0) },
            { "America/Asuncion",  new JsDate(2012, 9, 7, 3, 0, 0, 0) },
            { "America/Santiago",  new JsDate(2012, 9, 3, 3, 0, 0, 0) },
            { "America/Campo_Grande",  new JsDate(2012, 9, 21, 5, 0, 0, 0) },
            { "America/Montevideo",  new JsDate(2011, 9, 2, 3, 0, 0, 0) },
            { "America/Sao_Paulo",  new JsDate(2011, 9, 16, 5, 0, 0, 0) },
            { "America/Los_Angeles",  new JsDate(2011, 2, 13, 8, 0, 0, 0) },
            { "America/Santa_Isabel",  new JsDate(2011, 3, 5, 8, 0, 0, 0) },
            { "America/Havana",  new JsDate(2012, 2, 10, 2, 0, 0, 0) },
            { "America/New_York",  new JsDate(2012, 2, 10, 7, 0, 0, 0) },
            { "Europe/Helsinki",  new JsDate(2013, 2, 31, 5, 0, 0, 0) },
            { "Pacific/Auckland",  new JsDate(2011, 8, 26, 7, 0, 0, 0) },
            { "America/Halifax",  new JsDate(2011, 2, 13, 6, 0, 0, 0) },
            { "America/Goose_Bay",  new JsDate(2011, 2, 13, 2, 1, 0, 0) },
            { "America/Miquelon",  new JsDate(2011, 2, 13, 5, 0, 0, 0) },
            { "America/Godthab",  new JsDate(2011, 2, 27, 1, 0, 0, 0) },
            { "Europe/Moscow",  ru_pre_dst_change },
            { "Asia/Amman",  new JsDate(2013, 2, 29, 1, 0, 0, 0) },
            { "Asia/Beirut",  new JsDate(2013, 2, 31, 2, 0, 0, 0) },
            { "Asia/Damascus",  new JsDate(2013, 3, 6, 2, 0, 0, 0) },
            { "Asia/Jerusalem",  new JsDate(2013, 2, 29, 5, 0, 0, 0) },
            { "Asia/Yekaterinburg",  ru_pre_dst_change },
            { "Asia/Omsk",  ru_pre_dst_change },
            { "Asia/Krasnoyarsk",  ru_pre_dst_change },
            { "Asia/Irkutsk",  ru_pre_dst_change },
            { "Asia/Yakutsk",  ru_pre_dst_change },
            { "Asia/Vladivostok",  ru_pre_dst_change },
            { "Asia/Baku",  new JsDate(2013, 2, 31, 4, 0, 0) },
            { "Asia/Yerevan",  new JsDate(2013, 2, 31, 3, 0, 0) },
            { "Asia/Kamchatka",  ru_pre_dst_change },
            { "Asia/Gaza",  new JsDate(2010, 2, 27, 4, 0, 0) },
            { "Africa/Cairo",  new JsDate(2010, 4, 1, 3, 0, 0) },
            { "Europe/Minsk",  ru_pre_dst_change },
            { "Pacific/Apia",  new JsDate(2010, 10, 1, 1, 0, 0, 0) },
            { "Pacific/Fiji",  new JsDate(2010, 11, 1, 0, 0, 0) },
            { "Australia/Perth",  new JsDate(2008, 10, 1, 1, 0, 0, 0) }
        };

        /// <summary>
        /// The keys in this object are timezones that we know may be ambiguous after
        /// a preliminary scan through the olson_tz object.
        ///
        /// The array of timezones to compare must be in the order that daylight savings
        /// starts for the regions.
        /// </summary>
        private static Dictionary<string, string[]> AMBIGUITIES = new Dictionary<string, string[]>
        {
            { "America/Denver",       new[] { "America/Denver", "America/Mazatlan" } },
            { "America/Chicago",      new[] { "America/Chicago", "America/Mexico_City" } },
            { "America/Santiago",     new[] { "America/Santiago", "America/Asuncion", "America/Campo_Grande" } },
            { "America/Montevideo",   new[] { "America/Montevideo", "America/Sao_Paulo" } },
            { "Asia/Beirut",          new[] { "Asia/Amman", "Asia/Jerusalem", "Asia/Beirut", "Europe/Helsinki", "Asia/Damascus" } },
            { "Pacific/Auckland",     new[] { "Pacific/Auckland", "Pacific/Fiji" } },
            { "America/Los_Angeles",  new[] { "America/Los_Angeles", "America/Santa_Isabel" } },
            { "America/New_York",     new[] { "America/Havana", "America/New_York" } },
            { "America/Halifax",      new[] { "America/Goose_Bay", "America/Halifax" } },
            { "America/Godthab",      new[] { "America/Miquelon", "America/Godthab" } },
            { "Asia/Dubai",           new[] { "Europe/Moscow" } },
            { "Asia/Dhaka",           new[] { "Asia/Yekaterinburg" } },
            { "Asia/Jakarta",         new[] { "Asia/Omsk" } },
            { "Asia/Shanghai",        new[] { "Asia/Krasnoyarsk", "Australia/Perth" } },
            { "Asia/Tokyo",           new[] { "Asia/Irkutsk" } },
            { "Australia/Brisbane",   new[] { "Asia/Yakutsk" } },
            { "Pacific/Noumea",       new[] { "Asia/Vladivostok" } },
            { "Pacific/Tarawa",       new[] { "Asia/Kamchatka", "Pacific/Fiji" } },
            { "Pacific/Tongatapu",    new[] { "Pacific/Apia" } },
            { "Asia/Baghdad",         new[] { "Europe/Minsk" } },
            { "Asia/Baku",            new[] { "Asia/Yerevan", "Asia/Baku" } },
            { "Africa/Johannesburg",  new[] { "Asia/Gaza", "Africa/Cairo" } }
        };

        /// <summary>
        /// This object contains information on when daylight savings starts for
        /// different timezones.
        ///
        /// The list is short for a reason. Often we do not have to be very specific
        /// to single out the correct timezone. But when we do, this list comes in
        /// handy.
        ///
        /// Each value is a date denoting when daylight savings starts for that timezone.
        /// </summary>
        private static JsDate DstStartFor(string tz_name)
        {
            return dstStarts[tz_name];
        }

        private TimeZone(string standardName, TimeSpan offset)
        {
            StandardName = standardName;
            this.offset = offset;
            if (IsAmbiguous()) {
                AmbiguityCheck();
            }
        }

        /// <summary>
        /// Checks if a timezone has possible ambiguities. I.e timezones that are similar.
        ///
        /// For example, if the preliminary scan determines that we're in America/Denver.
        /// We double check here that we're really there and not in America/Mazatlan.
        ///
        /// This is done by checking known dates for when daylight savings start for different
        /// timezones during 2010 and 2011.
        /// </summary>
        private void AmbiguityCheck()
        {
            var ambiguity_list = AMBIGUITIES[StandardName];
            var length = ambiguity_list.Length;
            var i = 0;
            var tz = ambiguity_list[0];

            for (; i < length; i += 1) {
                tz = ambiguity_list[i];

                if (DateIsDst(DstStartFor(tz))) {
                    StandardName = tz;
                    return;
                }
            }
        }

        /// <summary>
        /// Checks if it is possible that the timezone is ambiguous.
        /// </summary>
        /// <returns></returns>
        private bool IsAmbiguous()
        {
            return AMBIGUITIES.ContainsKey(StandardName);
        }

        private static TimeZone FindCurrentTimezone()
        {
            var key = LookupKey();
            return new TimeZone(Timezones[key], TimeSpan.FromMinutes(-new JsDate().getTimezoneOffset()));
        }

        private static readonly Dictionary<string, string> Timezones = new Dictionary<string, string> 
        {
            { "-720,0", "Pacific/Majuro" },
            { "-660,0", "Pacific/Pago_Pago" },
            { "-600,1", "America/Adak" },
            { "-600,0", "Pacific/Honolulu" },
            { "-570,0", "Pacific/Marquesas" },
            { "-540,0", "Pacific/Gambier" },
            { "-540,1", "America/Anchorage" },
            { "-480,1", "America/Los_Angeles" },
            { "-480,0", "Pacific/Pitcairn" },
            { "-420,0", "America/Phoenix" },
            { "-420,1", "America/Denver" },
            { "-360,0", "America/Guatemala" },
            { "-360,1", "America/Chicago" },
            { "-360,1,s", "Pacific/Easter" },
            { "-300,0", "America/Bogota" },
            { "-300,1", "America/New_York" },
            { "-270,0", "America/Caracas" },
            { "-240,1", "America/Halifax" },
            { "-240,0", "America/Santo_Domingo" },
            { "-240,1,s", "America/Santiago" },
            { "-210,1", "America/St_Johns" },
            { "-180,1", "America/Godthab" },
            { "-180,0", "America/Argentina/Buenos_Aires" },
            { "-180,1,s", "America/Montevideo" },
            { "-120,0", "America/Noronha" },
            { "-120,1", "America/Noronha" },
            { "-60,1", "Atlantic/Azores" },
            { "-60,0", "Atlantic/Cape_Verde" },
            { "0,0", "UTC" },
            { "0,1", "Europe/London" },
            { "60,1", "Europe/Berlin" },
            { "60,0", "Africa/Lagos" },
            { "60,1,s", "Africa/Windhoek" },
            { "120,1", "Asia/Beirut" },
            { "120,0", "Africa/Johannesburg" },
            { "180,0", "Asia/Baghdad" },
            { "180,1", "Europe/Moscow" },
            { "210,1", "Asia/Tehran" },
            { "240,0", "Asia/Dubai" },
            { "240,1", "Asia/Baku" },
            { "270,0", "Asia/Kabul" },
            { "300,1", "Asia/Yekaterinburg" },
            { "300,0", "Asia/Karachi" },
            { "330,0", "Asia/Kolkata" },
            { "345,0", "Asia/Kathmandu" },
            { "360,0", "Asia/Dhaka" },
            { "360,1", "Asia/Omsk" },
            { "390,0", "Asia/Rangoon" },
            { "420,1", "Asia/Krasnoyarsk" },
            { "420,0", "Asia/Jakarta" },
            { "480,0", "Asia/Shanghai" },
            { "480,1", "Asia/Irkutsk" },
            { "525,0", "Australia/Eucla" },
            { "525,1,s", "Australia/Eucla" },
            { "540,1", "Asia/Yakutsk" },
            { "540,0", "Asia/Tokyo" },
            { "570,0", "Australia/Darwin" },
            { "570,1,s", "Australia/Adelaide" },
            { "600,0", "Australia/Brisbane" },
            { "600,1", "Asia/Vladivostok" },
            { "600,1,s", "Australia/Sydney" },
            { "630,1,s", "Australia/Lord_Howe" },
            { "660,1", "Asia/Kamchatka" },
            { "660,0", "Pacific/Noumea" },
            { "690,0", "Pacific/Norfolk" },
            { "720,1,s", "Pacific/Auckland" },
            { "720,0", "Pacific/Tarawa" },
            { "765,1,s", "Pacific/Chatham" },
            { "780,0", "Pacific/Tongatapu" },
            { "780,1,s", "Pacific/Apia" },
            { "840,0", "Pacific/Kiritimati" }
        };
    }
}