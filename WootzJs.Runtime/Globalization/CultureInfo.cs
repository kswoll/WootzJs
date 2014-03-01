#region License
//-----------------------------------------------------------------------
// <copyright>
// The MIT License (MIT)
// 
// Copyright (c) 2014 Kirk S Woll
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy of
// this software and associated documentation files (the "Software"), to deal in
// the Software without restriction, including without limitation the rights to
// use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of
// the Software, and to permit persons to whom the Software is furnished to do so,
// subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
// FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
// COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
// IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
// CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------
#endregion

namespace System.Globalization
{
    /// <summary>
    /// Provides information about a specific culture (called a locale for unmanaged code development). The information includes the names for the culture, the writing system, the calendar used, and formatting for dates and sort strings.
    /// </summary>
    public class CultureInfo : IFormatProvider
    {
        public static readonly CultureInfo CurrentCulture = new CultureInfo();
        public static readonly CultureInfo InvariantCulture = new CultureInfo();
        public static readonly CultureInfo Ordinal = new CultureInfo();
        public static readonly CultureInfo OrdinalIgnoreCase = new CultureInfo();

        public string Name { get; private set; }
        public CompareInfo CompareInfo { get; private set; }

        public CultureInfo()
        {
            CompareInfo = new CompareInfo();
        }

        public object GetFormat(Type formatType)
        {
            return null;
        }

/*
        private static readonly bool init = CultureInfo.Init();
        [OptionalField(VersionAdded = 1)] internal int cultureID = (int)sbyte.MaxValue;
        internal const int LOCALE_NEUTRAL = 0;
        internal const int LOCALE_CUSTOM_DEFAULT = 3072;
        internal const int LOCALE_CUSTOM_UNSPECIFIED = 4096;
        internal const int LOCALE_INVARIANT = 127;
        internal bool m_isReadOnly;
        internal CompareInfo compareInfo;
        internal TextInfo textInfo;
        [NonSerialized] internal RegionInfo regionInfo;
        internal NumberFormatInfo numInfo;
        internal DateTimeFormatInfo dateTimeInfo;
        internal Calendar calendar;
        [OptionalField(VersionAdded = 1)] internal int m_dataItem;
        [NonSerialized] internal CultureData m_cultureData;
        [NonSerialized] internal bool m_isInherited;
        [NonSerialized] private bool m_isSafeCrossDomain;
        [NonSerialized] private int m_createdDomainID;
        [NonSerialized] private CultureInfo m_consoleFallbackCulture;
        internal string m_name;
        [NonSerialized] private string m_nonSortName;
        [NonSerialized] private string m_sortName;
        private static volatile CultureInfo s_userDefaultCulture;
        private static volatile CultureInfo s_InvariantCultureInfo;
        private static volatile CultureInfo s_userDefaultUICulture;
        private static volatile CultureInfo s_InstalledUICultureInfo;
        private static volatile CultureInfo s_DefaultThreadCurrentUICulture;
        private static volatile CultureInfo s_DefaultThreadCurrentCulture;
        private static volatile Hashtable s_LcidCachedCultures;
        private static volatile Hashtable s_NameCachedCultures;
        [SecurityCritical] private static volatile WindowsRuntimeResourceManagerBase s_WindowsRuntimeResourceManager;
        [ThreadStatic] private static bool ts_IsDoingAppXCultureInfoLookup;
        [NonSerialized] private CultureInfo m_parent;
        private bool m_useUserOverride;
        private static volatile bool s_isTaiwanSku;
        private static volatile bool s_haveIsTaiwanSku;
        private const int LOCALE_USER_DEFAULT = 1024;
        private const int LOCALE_SYSTEM_DEFAULT = 2048;
        private const int LOCALE_TRADITIONAL_SPANISH = 1034;
        private const int LOCALE_SORTID_MASK = 983040;

        internal bool IsSafeCrossDomain
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.m_isSafeCrossDomain; }
        }

        internal int CreatedDomainID
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.m_createdDomainID; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.CultureInfo"/> object that represents the culture used by the current thread.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents the culture used by the current thread.
        /// </returns>
        [__DynamicallyInvokable]
        public static CultureInfo CurrentCulture
        {
            [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable] get { return Thread.CurrentThread.CurrentCulture; }
        }

        internal static CultureInfo UserDefaultCulture
        {
            get
            {
                CultureInfo cultureInfo = CultureInfo.s_userDefaultCulture;
                if (cultureInfo == null)
                {
                    CultureInfo.s_userDefaultCulture = CultureInfo.InvariantCulture;
                    cultureInfo = CultureInfo.InitUserDefaultCulture();
                    CultureInfo.s_userDefaultCulture = cultureInfo;
                }
                return cultureInfo;
            }
        }

        internal static CultureInfo UserDefaultUICulture
        {
            get
            {
                CultureInfo cultureInfo = CultureInfo.s_userDefaultUICulture;
                if (cultureInfo == null)
                {
                    CultureInfo.s_userDefaultUICulture = CultureInfo.InvariantCulture;
                    cultureInfo = CultureInfo.InitUserDefaultUICulture();
                    CultureInfo.s_userDefaultUICulture = cultureInfo;
                }
                return cultureInfo;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.CultureInfo"/> object that represents the current user interface culture used by the Resource Manager to look up culture-specific resources at run time.
        /// </summary>
        /// 
        /// <returns>
        /// The culture used by the Resource Manager to look up culture-specific resources at run time.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        [__DynamicallyInvokable]
        public static CultureInfo CurrentUICulture
        {
            [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable] get { return Thread.CurrentThread.CurrentUICulture; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.CultureInfo"/> that represents the culture installed with the operating system.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Globalization.CultureInfo"/> that represents the culture installed with the operating system.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public static CultureInfo InstalledUICulture
        {
            get
            {
                CultureInfo cultureInfo = CultureInfo.s_InstalledUICultureInfo;
                if (cultureInfo == null)
                {
                    cultureInfo = CultureInfo.GetCultureByName(CultureInfo.GetSystemDefaultUILanguage(), true) ?? CultureInfo.InvariantCulture;
                    cultureInfo.m_isReadOnly = true;
                    CultureInfo.s_InstalledUICultureInfo = cultureInfo;
                }
                return cultureInfo;
            }
        }

        /// <summary>
        /// Gets or sets the default culture for threads in the current application domain.
        /// </summary>
        /// 
        /// <returns>
        /// The default culture for threads in the current application domain, or null if the current system culture is the default thread culture in the application domain.
        /// </returns>
        [__DynamicallyInvokable]
        public static CultureInfo DefaultThreadCurrentCulture
        {
            [__DynamicallyInvokable] get { return CultureInfo.s_DefaultThreadCurrentCulture; }
            [SecuritySafeCritical, __DynamicallyInvokable, SecurityPermission(SecurityAction.Demand, ControlThread = true)] set { CultureInfo.s_DefaultThreadCurrentCulture = value; }
        }

        /// <summary>
        /// Gets or sets the default UI culture for threads in the current application domain.
        /// </summary>
        /// 
        /// <returns>
        /// The default UI culture for threads in the current application domain, or null if the current system UI culture is the default thread UI culture in the application domain.
        /// </returns>
        /// <exception cref="T:System.ArgumentException">In a set operation, the <see cref="P:System.Globalization.CultureInfo.Name"/> property value is invalid. </exception>
        [__DynamicallyInvokable]
        public static CultureInfo DefaultThreadCurrentUICulture
        {
            [__DynamicallyInvokable] get { return CultureInfo.s_DefaultThreadCurrentUICulture; }
            [SecuritySafeCritical, __DynamicallyInvokable, SecurityPermission(SecurityAction.Demand, ControlThread = true)]
            set
            {
                if (value != null)
                    CultureInfo.VerifyCultureName(value, true);
                CultureInfo.s_DefaultThreadCurrentUICulture = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.CultureInfo"/> object that is culture-independent (invariant).
        /// </summary>
        /// 
        /// <returns>
        /// The object that is culture-independent (invariant).
        /// </returns>
        [__DynamicallyInvokable]
        public static CultureInfo InvariantCulture
        {
            [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries"), __DynamicallyInvokable] get { return CultureInfo.s_InvariantCultureInfo; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.CultureInfo"/> that represents the parent culture of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Globalization.CultureInfo"/> that represents the parent culture of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        [__DynamicallyInvokable]
        public virtual CultureInfo Parent
        {
            [SecuritySafeCritical, __DynamicallyInvokable]
            get
            {
                if (this.m_parent == null)
                {
                    try
                    {
                        string sparent = this.m_cultureData.SPARENT;
                        this.m_parent = !string.IsNullOrEmpty(sparent) ? new CultureInfo(sparent, this.m_cultureData.UseUserOverride) : CultureInfo.InvariantCulture;
                    }
                    catch (ArgumentException ex)
                    {
                        this.m_parent = CultureInfo.InvariantCulture;
                    }
                }
                return this.m_parent;
            }
        }

        /// <summary>
        /// Gets the culture identifier for the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The culture identifier for the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        public virtual int LCID
        {
            [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")] get { return this.m_cultureData.ILANGUAGE; }
        }

        /// <summary>
        /// Gets the active input locale identifier.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed number that specifies an input locale identifier.
        /// </returns>
        [ComVisible(false)]
        public virtual int KeyboardLayoutId
        {
            get { return this.m_cultureData.IINPUTLANGUAGEHANDLE; }
        }

        /// <summary>
        /// Gets the culture name in the format languagecode2-country/regioncode2.
        /// </summary>
        /// 
        /// <returns>
        /// The culture name in the format languagecode2-country/regioncode2, where languagecode2 is a lowercase two-letter code derived from ISO 639-1 and country/regioncode2 is an uppercase two-letter code derived from ISO 3166.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual string Name
        {
            [__DynamicallyInvokable]
            get
            {
                if (this.m_nonSortName == null)
                {
                    this.m_nonSortName = this.m_cultureData.SNAME;
                    if (this.m_nonSortName == null)
                        this.m_nonSortName = string.Empty;
                }
                return this.m_nonSortName;
            }
        }

        internal string SortName
        {
            get
            {
                if (this.m_sortName == null)
                    this.m_sortName = this.m_cultureData.SCOMPAREINFO;
                return this.m_sortName;
            }
        }

        /// <summary>
        /// Deprecated. Gets the RFC 4646 standard identification for a language.
        /// </summary>
        /// 
        /// <returns>
        /// A string that is the RFC 4646 standard identification for a language.
        /// </returns>
        [ComVisible(false)]
        public string IetfLanguageTag
        {
            get
            {
                switch (this.Name)
                {
                    case "zh-CHT":
                        return "zh-Hant";
                    case "zh-CHS":
                        return "zh-Hans";
                    default:
                        return this.Name;
                }
            }
        }

        /// <summary>
        /// Gets the full localized culture name.
        /// </summary>
        /// 
        /// <returns>
        /// The full localized culture name in the format languagefull [country/regionfull], where languagefull is the full name of the language and country/regionfull is the full name of the country/region.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual string DisplayName
        {
            [SecuritySafeCritical, __DynamicallyInvokable] get { return this.m_cultureData.SLOCALIZEDDISPLAYNAME; }
        }

        /// <summary>
        /// Gets the culture name, consisting of the language, the country/region, and the optional script, that the culture is set to display.
        /// </summary>
        /// 
        /// <returns>
        /// The culture name. consisting of the full name of the language, the full name of the country/region, and the optional script. The format is discussed in the description of the <see cref="T:System.Globalization.CultureInfo"/> class.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual string NativeName
        {
            [SecuritySafeCritical, __DynamicallyInvokable] get { return this.m_cultureData.SNATIVEDISPLAYNAME; }
        }

        /// <summary>
        /// Gets the culture name in the format languagefull [country/regionfull] in English.
        /// </summary>
        /// 
        /// <returns>
        /// The culture name in the format languagefull [country/regionfull] in English, where languagefull is the full name of the language and country/regionfull is the full name of the country/region.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual string EnglishName
        {
            [SecuritySafeCritical, __DynamicallyInvokable] get { return this.m_cultureData.SENGDISPLAYNAME; }
        }

        /// <summary>
        /// Gets the ISO 639-1 two-letter code for the language of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The ISO 639-1 two-letter code for the language of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual string TwoLetterISOLanguageName
        {
            [SecuritySafeCritical, __DynamicallyInvokable] get { return this.m_cultureData.SISO639LANGNAME; }
        }

        /// <summary>
        /// Gets the ISO 639-2 three-letter code for the language of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The ISO 639-2 three-letter code for the language of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        public virtual string ThreeLetterISOLanguageName
        {
            [SecuritySafeCritical] get { return this.m_cultureData.SISO639LANGNAME2; }
        }

        /// <summary>
        /// Gets the three-letter code for the language as defined in the Windows API.
        /// </summary>
        /// 
        /// <returns>
        /// The three-letter code for the language as defined in the Windows API.
        /// </returns>
        public virtual string ThreeLetterWindowsLanguageName
        {
            [SecuritySafeCritical] get { return this.m_cultureData.SABBREVLANGNAME; }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.CompareInfo"/> that defines how to compare strings for the culture.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Globalization.CompareInfo"/> that defines how to compare strings for the culture.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        [__DynamicallyInvokable]
        public virtual CompareInfo CompareInfo
        {
            [__DynamicallyInvokable]
            get
            {
                if (this.compareInfo == null)
                {
                    CompareInfo compareInfo = this.UseUserOverride ? CultureInfo.GetCultureInfo(this.m_name).CompareInfo : new CompareInfo(this);
                    if (!CompatibilitySwitches.IsCompatibilityBehaviorDefined)
                        return compareInfo;
                    this.compareInfo = compareInfo;
                }
                return this.compareInfo;
            }
        }

        private RegionInfo Region
        {
            get
            {
                if (this.regionInfo == null)
                    this.regionInfo = new RegionInfo(this.m_cultureData);
                return this.regionInfo;
            }
        }

        /// <summary>
        /// Gets the <see cref="T:System.Globalization.TextInfo"/> that defines the writing system associated with the culture.
        /// </summary>
        /// 
        /// <returns>
        /// The <see cref="T:System.Globalization.TextInfo"/> that defines the writing system associated with the culture.
        /// </returns>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        [__DynamicallyInvokable]
        public virtual TextInfo TextInfo
        {
            [__DynamicallyInvokable]
            get
            {
                if (this.textInfo == null)
                {
                    TextInfo textInfo = new TextInfo(this.m_cultureData);
                    textInfo.SetReadOnlyState(this.m_isReadOnly);
                    if (!CompatibilitySwitches.IsCompatibilityBehaviorDefined)
                        return textInfo;
                    this.textInfo = textInfo;
                }
                return this.textInfo;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="T:System.Globalization.CultureInfo"/> represents a neutral culture.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current <see cref="T:System.Globalization.CultureInfo"/> represents a neutral culture; otherwise, false.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual bool IsNeutralCulture
        {
            [__DynamicallyInvokable] get { return this.m_cultureData.IsNeutralCulture; }
        }

        /// <summary>
        /// Gets the culture types that pertain to the current <see cref="T:System.Globalization.CultureInfo"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A bitwise combination of one or more <see cref="T:System.Globalization.CultureTypes"/> values. There is no default value.
        /// </returns>
        [ComVisible(false)]
        public CultureTypes CultureTypes
        {
            get
            {
                CultureTypes cultureTypes = (CultureTypes)0;
                return (CultureTypes)((!this.m_cultureData.IsNeutralCulture ? (int)(cultureTypes | CultureTypes.SpecificCultures) : (int)(cultureTypes | CultureTypes.NeutralCultures)) | (this.m_cultureData.IsWin32Installed ? 4 : 0) | (this.m_cultureData.IsFramework ? 64 : 0) | (this.m_cultureData.IsSupplementalCustomCulture ? 8 : 0) | (this.m_cultureData.IsReplacementCulture ? 24 : 0));
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Globalization.NumberFormatInfo"/> that defines the culturally appropriate format of displaying numbers, currency, and percentage.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Globalization.NumberFormatInfo"/> that defines the culturally appropriate format of displaying numbers, currency, and percentage.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The property is set to null. </exception><exception cref="T:System.InvalidOperationException">The <see cref="P:System.Globalization.CultureInfo.NumberFormat"/> property or any of the <see cref="T:System.Globalization.NumberFormatInfo"/> properties is set, and the <see cref="T:System.Globalization.CultureInfo"/> is read-only. </exception>
        [__DynamicallyInvokable]
        public virtual NumberFormatInfo NumberFormat
        {
            [__DynamicallyInvokable]
            get
            {
                if (this.numInfo == null)
                    this.numInfo = new NumberFormatInfo(this.m_cultureData)
                    {
                        isReadOnly = this.m_isReadOnly
                    };
                return this.numInfo;
            }
            [__DynamicallyInvokable]
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", Environment.GetResourceString("ArgumentNull_Obj"));
                this.VerifyWritable();
                this.numInfo = value;
            }
        }

        /// <summary>
        /// Gets or sets a <see cref="T:System.Globalization.DateTimeFormatInfo"/> that defines the culturally appropriate format of displaying dates and times.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Globalization.DateTimeFormatInfo"/> that defines the culturally appropriate format of displaying dates and times.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">The property is set to null. </exception><exception cref="T:System.InvalidOperationException">The <see cref="P:System.Globalization.CultureInfo.DateTimeFormat"/> property or any of the <see cref="T:System.Globalization.DateTimeFormatInfo"/> properties is set, and the <see cref="T:System.Globalization.CultureInfo"/> is read-only. </exception>
        [__DynamicallyInvokable]
        public virtual DateTimeFormatInfo DateTimeFormat
        {
            [__DynamicallyInvokable]
            get
            {
                if (this.dateTimeInfo == null)
                {
                    DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo(this.m_cultureData, this.Calendar);
                    dateTimeFormatInfo.m_isReadOnly = this.m_isReadOnly;
                    Thread.MemoryBarrier();
                    this.dateTimeInfo = dateTimeFormatInfo;
                }
                return this.dateTimeInfo;
            }
            [__DynamicallyInvokable]
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value", Environment.GetResourceString("ArgumentNull_Obj"));
                this.VerifyWritable();
                this.dateTimeInfo = value;
            }
        }

        /// <summary>
        /// Gets the default calendar used by the culture.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Globalization.Calendar"/> that represents the default calendar used by the culture.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual Calendar Calendar
        {
            [__DynamicallyInvokable]
            get
            {
                if (this.calendar == null)
                {
                    Calendar defaultCalendar = this.m_cultureData.DefaultCalendar;
                    Thread.MemoryBarrier();
                    defaultCalendar.SetReadOnlyState(this.m_isReadOnly);
                    this.calendar = defaultCalendar;
                }
                return this.calendar;
            }
        }

        /// <summary>
        /// Gets the list of calendars that can be used by the culture.
        /// </summary>
        /// 
        /// <returns>
        /// An array of type <see cref="T:System.Globalization.Calendar"/> that represents the calendars that can be used by the culture represented by the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual Calendar[] OptionalCalendars
        {
            [__DynamicallyInvokable]
            get
            {
                int[] calendarIds = this.m_cultureData.CalendarIds;
                Calendar[] calendarArray = new Calendar[calendarIds.Length];
                for (int index = 0; index < calendarArray.Length; ++index)
                    calendarArray[index] = CultureInfo.GetCalendarInstance(calendarIds[index]);
                return calendarArray;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="T:System.Globalization.CultureInfo"/> uses the user-selected culture settings.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current <see cref="T:System.Globalization.CultureInfo"/> uses the user-selected culture settings; otherwise, false.
        /// </returns>
        public bool UseUserOverride
        {
            get { return this.m_cultureData.UseUserOverride; }
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="T:System.Globalization.CultureInfo"/> is read-only.
        /// </summary>
        /// 
        /// <returns>
        /// true if the current <see cref="T:System.Globalization.CultureInfo"/> is read-only; otherwise, false. The default is false.
        /// </returns>
        [__DynamicallyInvokable]
        public bool IsReadOnly
        {
            [__DynamicallyInvokable, TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")] get { return this.m_isReadOnly; }
        }

        internal bool HasInvariantCultureName
        {
            get { return this.Name == CultureInfo.InvariantCulture.Name; }
        }

        internal static bool IsTaiwanSku
        {
            get
            {
                if (!CultureInfo.s_haveIsTaiwanSku)
                {
                    CultureInfo.s_isTaiwanSku = CultureInfo.GetSystemDefaultUILanguage() == "zh-TW";
                    CultureInfo.s_haveIsTaiwanSku = true;
                }
                return CultureInfo.s_isTaiwanSku;
            }
        }

        static CultureInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Globalization.CultureInfo"/> class based on the culture specified by name.
        /// </summary>
        /// <param name="name">A predefined <see cref="T:System.Globalization.CultureInfo"/> name, <see cref="P:System.Globalization.CultureInfo.Name"/> of an existing <see cref="T:System.Globalization.CultureInfo"/>, or Windows-only culture name. <paramref name="name"/> is not case-sensitive.</param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="name"/> is not a valid culture name.</exception>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [__DynamicallyInvokable]
        public CultureInfo(string name)
            : this(name, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Globalization.CultureInfo"/> class based on the culture specified by name and on the Boolean that specifies whether to use the user-selected culture settings from the system.
        /// </summary>
        /// <param name="name">A predefined <see cref="T:System.Globalization.CultureInfo"/> name, <see cref="P:System.Globalization.CultureInfo.Name"/> of an existing <see cref="T:System.Globalization.CultureInfo"/>, or Windows-only culture name. <paramref name="name"/> is not case-sensitive.</param><param name="useUserOverride">A Boolean that denotes whether to use the user-selected culture settings (true) or the default culture settings (false). </param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null. </exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="name"/> is not a valid culture name.</exception>
        public CultureInfo(string name, bool useUserOverride)
        {
            if (name == null)
                throw new ArgumentNullException("name", Environment.GetResourceString("ArgumentNull_String"));
            this.m_cultureData = CultureData.GetCultureData(name, useUserOverride);
            if (this.m_cultureData == null)
                throw new CultureNotFoundException("name", name, Environment.GetResourceString("Argument_CultureNotSupported"));
            this.m_name = this.m_cultureData.CultureName;
            this.m_isInherited = this.GetType() != typeof(CultureInfo);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Globalization.CultureInfo"/> class based on the culture specified by the culture identifier.
        /// </summary>
        /// <param name="culture">A predefined <see cref="T:System.Globalization.CultureInfo"/> identifier, <see cref="P:System.Globalization.CultureInfo.LCID"/> property of an existing <see cref="T:System.Globalization.CultureInfo"/> object, or Windows-only culture identifier. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="culture"/> is less than zero. </exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="culture"/> is not a valid culture identifier. </exception>
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        public CultureInfo(int culture)
            : this(culture, true)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Globalization.CultureInfo"/> class based on the culture specified by the culture identifier and on the Boolean that specifies whether to use the user-selected culture settings from the system.
        /// </summary>
        /// <param name="culture">A predefined <see cref="T:System.Globalization.CultureInfo"/> identifier, <see cref="P:System.Globalization.CultureInfo.LCID"/> property of an existing <see cref="T:System.Globalization.CultureInfo"/> object, or Windows-only culture identifier. </param><param name="useUserOverride">A Boolean that denotes whether to use the user-selected culture settings (true) or the default culture settings (false). </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="culture"/> is less than zero. </exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="culture"/> is not a valid culture identifier.</exception>
        public CultureInfo(int culture, bool useUserOverride)
        {
            if (culture < 0)
                throw new ArgumentOutOfRangeException("culture", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
            this.InitializeFromCultureId(culture, useUserOverride);
        }

        internal CultureInfo(string cultureName, string textAndCompareCultureName)
        {
            if (cultureName == null)
                throw new ArgumentNullException("cultureName", Environment.GetResourceString("ArgumentNull_String"));
            this.m_cultureData = CultureData.GetCultureData(cultureName, false);
            if (this.m_cultureData == null)
                throw new CultureNotFoundException("cultureName", cultureName, Environment.GetResourceString("Argument_CultureNotSupported"));
            this.m_name = this.m_cultureData.CultureName;
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(textAndCompareCultureName);
            this.compareInfo = cultureInfo.CompareInfo;
            this.textInfo = cultureInfo.TextInfo;
        }

        [SecuritySafeCritical]
        internal static CultureInfo GetCultureInfoForUserPreferredLanguageInAppX()
        {
            if (CultureInfo.ts_IsDoingAppXCultureInfoLookup)
                return (CultureInfo)null;
            if (AppDomain.IsAppXNGen)
                return (CultureInfo)null;
            try
            {
                CultureInfo.ts_IsDoingAppXCultureInfoLookup = true;
                if (CultureInfo.s_WindowsRuntimeResourceManager == null)
                    CultureInfo.s_WindowsRuntimeResourceManager = ResourceManager.GetWinRTResourceManager();
                return CultureInfo.s_WindowsRuntimeResourceManager.GlobalResourceContextBestFitCultureInfo;
            }
            finally
            {
                CultureInfo.ts_IsDoingAppXCultureInfoLookup = false;
            }
        }

        internal static void CheckDomainSafetyObject(object obj, object container)
        {
            if (!(obj.GetType().Assembly != typeof(CultureInfo).Assembly))
                return;
            throw new InvalidOperationException(string.Format((IFormatProvider)CultureInfo.CurrentCulture, Environment.GetResourceString("InvalidOperation_SubclassedObject"), new object[2]
            {
                (object)obj.GetType(),
                (object)container.GetType()
            }));
        }

        internal bool CanSendCrossDomain()
        {
            bool flag = false;
            if (this.GetType() == typeof(CultureInfo))
                flag = true;
            return flag;
        }

        internal void StartCrossDomainTracking()
        {
            if (this.m_createdDomainID != 0)
                return;
            if (this.CanSendCrossDomain())
                this.m_isSafeCrossDomain = true;
            Thread.MemoryBarrier();
            this.m_createdDomainID = Thread.GetDomainID();
        }

        /// <summary>
        /// Creates a <see cref="T:System.Globalization.CultureInfo"/> that represents the specific culture that is associated with the specified name.
        /// </summary>
        /// 
        /// <returns>
        /// A <see cref="T:System.Globalization.CultureInfo"/> object that represents:The invariant culture, if <paramref name="name"/> is an empty string ("").-or- The specific culture associated with <paramref name="name"/>, if <paramref name="name"/> is a neutral culture.-or- The culture specified by <paramref name="name"/>, if <paramref name="name"/> is already a specific culture.
        /// </returns>
        /// <param name="name">A predefined <see cref="T:System.Globalization.CultureInfo"/> name or the name of an existing <see cref="T:System.Globalization.CultureInfo"/> object. <paramref name="name"/> is not case-sensitive.</param><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="name"/> is not a valid culture name.-or- The culture specified by <paramref name="name"/> does not have a specific culture associated with it. </exception><exception cref="T:System.NullReferenceException"><paramref name="name"/> is null. </exception>
        public static CultureInfo CreateSpecificCulture(string name)
        {
            CultureInfo cultureInfo;
            try
            {
                cultureInfo = new CultureInfo(name);
            }
            catch (ArgumentException ex1)
            {
                cultureInfo = (CultureInfo)null;
                for (int length = 0; length < name.Length; ++length)
                {
                    if (45 == (int)name[length])
                    {
                        try
                        {
                            cultureInfo = new CultureInfo(name.Substring(0, length));
                            break;
                        }
                        catch (ArgumentException ex2)
                        {
                            throw;
                        }
                    }
                }
                if (cultureInfo == null)
                    throw;
            }
            if (!cultureInfo.IsNeutralCulture)
                return cultureInfo;
            else
                return new CultureInfo(cultureInfo.m_cultureData.SSPECIFICCULTURE);
        }

        internal static bool VerifyCultureName(string cultureName, bool throwException)
        {
            for (int index = 0; index < cultureName.Length; ++index)
            {
                char c = cultureName[index];
                if (!char.IsLetterOrDigit(c) && (int)c != 45 && (int)c != 95)
                {
                    if (!throwException)
                        return false;
                    throw new ArgumentException(Environment.GetResourceString("Argument_InvalidResourceCultureName", new object[1]
                    {
                        (object)cultureName
                    }));
                }
            }
            return true;
        }

        internal static bool VerifyCultureName(CultureInfo culture, bool throwException)
        {
            if (!culture.m_isInherited)
                return true;
            else
                return CultureInfo.VerifyCultureName(culture.Name, throwException);
        }

        /// <summary>
        /// Gets the list of supported cultures filtered by the specified <see cref="T:System.Globalization.CultureTypes"/> parameter.
        /// </summary>
        /// 
        /// <returns>
        /// An array that contains the cultures specified by the <paramref name="types"/> parameter. The array of cultures is unsorted.
        /// </returns>
        /// <param name="types">A bitwise combination of the enumeration values that filter the cultures to retrieve. </param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="types"/> specifies an invalid combination of <see cref="T:System.Globalization.CultureTypes"/> values.</exception><PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public static CultureInfo[] GetCultures(CultureTypes types)
        {
            if ((types & CultureTypes.UserCustomCulture) == CultureTypes.UserCustomCulture)
                types |= CultureTypes.ReplacementCultures;
            return CultureData.GetCultures(types);
        }

        /// <summary>
        /// Determines whether the specified object is the same culture as the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if <paramref name="value"/> is the same culture as the current <see cref="T:System.Globalization.CultureInfo"/>; otherwise, false.
        /// </returns>
        /// <param name="value">The object to compare with the current <see cref="T:System.Globalization.CultureInfo"/>. </param>
        [__DynamicallyInvokable]
        public override bool Equals(object value)
        {
            if (object.ReferenceEquals((object)this, value))
                return true;
            CultureInfo cultureInfo = value as CultureInfo;
            if (cultureInfo != null && this.Name.Equals(cultureInfo.Name))
                return this.CompareInfo.Equals((object)cultureInfo.CompareInfo);
            else
                return false;
        }

        /// <summary>
        /// Serves as a hash function for the current <see cref="T:System.Globalization.CultureInfo"/>, suitable for hashing algorithms and data structures, such as a hash table.
        /// </summary>
        /// 
        /// <returns>
        /// A hash code for the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        [TargetedPatchingOptOut("Performance critical to inline across NGen image boundaries")]
        [__DynamicallyInvokable]
        public override int GetHashCode()
        {
            return this.Name.GetHashCode() + this.CompareInfo.GetHashCode();
        }

        /// <summary>
        /// Returns a string containing the name of the current <see cref="T:System.Globalization.CultureInfo"/> in the format languagecode2-country/regioncode2.
        /// </summary>
        /// 
        /// <returns>
        /// A string containing the name of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        [__DynamicallyInvokable]
        public override string ToString()
        {
            return this.m_name;
        }

        /// <summary>
        /// Gets an object that defines how to format the specified type.
        /// </summary>
        /// 
        /// <returns>
        /// The value of the <see cref="P:System.Globalization.CultureInfo.NumberFormat"/> property, which is a <see cref="T:System.Globalization.NumberFormatInfo"/> containing the default number format information for the current <see cref="T:System.Globalization.CultureInfo"/>, if <paramref name="formatType"/> is the <see cref="T:System.Type"/> object for the <see cref="T:System.Globalization.NumberFormatInfo"/> class.-or- The value of the <see cref="P:System.Globalization.CultureInfo.DateTimeFormat"/> property, which is a <see cref="T:System.Globalization.DateTimeFormatInfo"/> containing the default date and time format information for the current <see cref="T:System.Globalization.CultureInfo"/>, if <paramref name="formatType"/> is the <see cref="T:System.Type"/> object for the <see cref="T:System.Globalization.DateTimeFormatInfo"/> class.-or- null, if <paramref name="formatType"/> is any other object.
        /// </returns>
        /// <param name="formatType">The <see cref="T:System.Type"/> for which to get a formatting object. This method only supports the <see cref="T:System.Globalization.NumberFormatInfo"/> and <see cref="T:System.Globalization.DateTimeFormatInfo"/> types. </param>
        [__DynamicallyInvokable]
        public virtual object GetFormat(Type formatType)
        {
            if (formatType == typeof(NumberFormatInfo))
                return (object)this.NumberFormat;
            if (formatType == typeof(DateTimeFormatInfo))
                return (object)this.DateTimeFormat;
            else
                return (object)null;
        }

        /// <summary>
        /// Refreshes cached culture-related information.
        /// </summary>
        /// <PermissionSet><IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode"/></PermissionSet>
        public void ClearCachedData()
        {
            CultureInfo.s_userDefaultUICulture = (CultureInfo)null;
            CultureInfo.s_userDefaultCulture = (CultureInfo)null;
            RegionInfo.s_currentRegionInfo = (RegionInfo)null;
            TimeZone.ResetTimeZone();
            TimeZoneInfo.ClearCachedData();
            CultureInfo.s_LcidCachedCultures = (Hashtable)null;
            CultureInfo.s_NameCachedCultures = (Hashtable)null;
            CultureData.ClearCachedData();
        }

        internal static Calendar GetCalendarInstance(int calType)
        {
            if (calType == 1)
                return (Calendar)new GregorianCalendar();
            else
                return CultureInfo.GetCalendarInstanceRare(calType);
        }

        internal static Calendar GetCalendarInstanceRare(int calType)
        {
            switch (calType)
            {
                case 2:
                case 9:
                case 10:
                case 11:
                case 12:
                    return (Calendar)new GregorianCalendar((GregorianCalendarTypes)calType);
                case 3:
                    return (Calendar)new JapaneseCalendar();
                case 4:
                    return (Calendar)new TaiwanCalendar();
                case 5:
                    return (Calendar)new KoreanCalendar();
                case 6:
                    return (Calendar)new HijriCalendar();
                case 7:
                    return (Calendar)new ThaiBuddhistCalendar();
                case 8:
                    return (Calendar)new HebrewCalendar();
                case 14:
                    return (Calendar)new JapaneseLunisolarCalendar();
                case 15:
                    return (Calendar)new ChineseLunisolarCalendar();
                case 20:
                    return (Calendar)new KoreanLunisolarCalendar();
                case 21:
                    return (Calendar)new TaiwanLunisolarCalendar();
                case 22:
                    return (Calendar)new PersianCalendar();
                case 23:
                    return (Calendar)new UmAlQuraCalendar();
                default:
                    return (Calendar)new GregorianCalendar();
            }
        }

        /// <summary>
        /// Gets an alternate user interface culture suitable for console applications when the default graphic user interface culture is unsuitable.
        /// </summary>
        /// 
        /// <returns>
        /// An alternate culture that is used to read and display text on the console.
        /// </returns>
        [ComVisible(false)]
        [SecuritySafeCritical]
        public CultureInfo GetConsoleFallbackUICulture()
        {
            CultureInfo cultureInfo = this.m_consoleFallbackCulture;
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.CreateSpecificCulture(this.m_cultureData.SCONSOLEFALLBACKNAME);
                cultureInfo.m_isReadOnly = true;
                this.m_consoleFallbackCulture = cultureInfo;
            }
            return cultureInfo;
        }

        /// <summary>
        /// Creates a copy of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A copy of the current <see cref="T:System.Globalization.CultureInfo"/>.
        /// </returns>
        [__DynamicallyInvokable]
        public virtual object Clone()
        {
            CultureInfo cultureInfo = (CultureInfo)this.MemberwiseClone();
            cultureInfo.m_isReadOnly = false;
            if (!this.m_isInherited)
            {
                if (this.dateTimeInfo != null)
                    cultureInfo.dateTimeInfo = (DateTimeFormatInfo)this.dateTimeInfo.Clone();
                if (this.numInfo != null)
                    cultureInfo.numInfo = (NumberFormatInfo)this.numInfo.Clone();
            }
            else
            {
                cultureInfo.DateTimeFormat = (DateTimeFormatInfo)this.DateTimeFormat.Clone();
                cultureInfo.NumberFormat = (NumberFormatInfo)this.NumberFormat.Clone();
            }
            if (this.textInfo != null)
                cultureInfo.textInfo = (TextInfo)this.textInfo.Clone();
            if (this.calendar != null)
                cultureInfo.calendar = (Calendar)this.calendar.Clone();
            return (object)cultureInfo;
        }

        /// <summary>
        /// Returns a read-only wrapper around the specified <see cref="T:System.Globalization.CultureInfo"/>.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="T:System.Globalization.CultureInfo"/> wrapper around <paramref name="ci"/>.
        /// </returns>
        /// <param name="ci">The <see cref="T:System.Globalization.CultureInfo"/> to wrap. </param><exception cref="T:System.ArgumentNullException"><paramref name="ci"/> is null. </exception>
        [__DynamicallyInvokable]
        public static CultureInfo ReadOnly(CultureInfo ci)
        {
            if (ci == null)
                throw new ArgumentNullException("ci");
            if (ci.IsReadOnly)
                return ci;
            CultureInfo cultureInfo = (CultureInfo)ci.MemberwiseClone();
            if (!ci.IsNeutralCulture)
            {
                if (!ci.m_isInherited)
                {
                    if (ci.dateTimeInfo != null)
                        cultureInfo.dateTimeInfo = DateTimeFormatInfo.ReadOnly(ci.dateTimeInfo);
                    if (ci.numInfo != null)
                        cultureInfo.numInfo = NumberFormatInfo.ReadOnly(ci.numInfo);
                }
                else
                {
                    cultureInfo.DateTimeFormat = DateTimeFormatInfo.ReadOnly(ci.DateTimeFormat);
                    cultureInfo.NumberFormat = NumberFormatInfo.ReadOnly(ci.NumberFormat);
                }
            }
            if (ci.textInfo != null)
                cultureInfo.textInfo = TextInfo.ReadOnly(ci.textInfo);
            if (ci.calendar != null)
                cultureInfo.calendar = Calendar.ReadOnly(ci.calendar);
            cultureInfo.m_isReadOnly = true;
            return cultureInfo;
        }

        internal static CultureInfo GetCultureInfoHelper(int lcid, string name, string altName)
        {
            Hashtable hashtable1 = CultureInfo.s_NameCachedCultures;
            if (name != null)
                name = CultureData.AnsiToLower(name);
            if (altName != null)
                altName = CultureData.AnsiToLower(altName);
            if (hashtable1 == null)
                hashtable1 = Hashtable.Synchronized(new Hashtable());
            else if (lcid == -1)
            {
                CultureInfo cultureInfo = (CultureInfo)hashtable1[(object)(name + (object)'?' + altName)];
                if (cultureInfo != null)
                    return cultureInfo;
            }
            else if (lcid == 0)
            {
                CultureInfo cultureInfo = (CultureInfo)hashtable1[(object)name];
                if (cultureInfo != null)
                    return cultureInfo;
            }
            Hashtable hashtable2 = CultureInfo.s_LcidCachedCultures;
            if (hashtable2 == null)
                hashtable2 = Hashtable.Synchronized(new Hashtable());
            else if (lcid > 0)
            {
                CultureInfo cultureInfo = (CultureInfo)hashtable2[(object)lcid];
                if (cultureInfo != null)
                    return cultureInfo;
            }
            CultureInfo cultureInfo1;
            try
            {
                switch (lcid)
                {
                    case -1:
                        cultureInfo1 = new CultureInfo(name, altName);
                        break;
                    case 0:
                        cultureInfo1 = new CultureInfo(name, false);
                        break;
                    default:
                        cultureInfo1 = new CultureInfo(lcid, false);
                        break;
                }
            }
            catch (ArgumentException ex)
            {
                return (CultureInfo)null;
            }
            cultureInfo1.m_isReadOnly = true;
            if (lcid == -1)
            {
                hashtable1[(object)(name + (object)'?' + altName)] = (object)cultureInfo1;
                cultureInfo1.TextInfo.SetReadOnlyState(true);
            }
            else
            {
                string str = CultureData.AnsiToLower(cultureInfo1.m_name);
                hashtable1[(object)str] = (object)cultureInfo1;
                if ((cultureInfo1.LCID != 4 || !(str == "zh-hans")) && (cultureInfo1.LCID != 31748 || !(str == "zh-hant")))
                    hashtable2[(object)cultureInfo1.LCID] = (object)cultureInfo1;
            }
            if (-1 != lcid)
                CultureInfo.s_LcidCachedCultures = hashtable2;
            CultureInfo.s_NameCachedCultures = hashtable1;
            return cultureInfo1;
        }

        /// <summary>
        /// Retrieves a cached, read-only instance of a culture by using the specified culture identifier.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="T:System.Globalization.CultureInfo"/> object.
        /// </returns>
        /// <param name="culture">A locale identifier (LCID).</param><exception cref="T:System.ArgumentOutOfRangeException"><paramref name="culture"/> is less than zero.</exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="culture"/> specifies a culture that is not supported.</exception>
        public static CultureInfo GetCultureInfo(int culture)
        {
            if (culture <= 0)
                throw new ArgumentOutOfRangeException("culture", Environment.GetResourceString("ArgumentOutOfRange_NeedPosNum"));
            CultureInfo cultureInfoHelper = CultureInfo.GetCultureInfoHelper(culture, (string)null, (string)null);
            if (cultureInfoHelper == null)
                throw new CultureNotFoundException("culture", culture, Environment.GetResourceString("Argument_CultureNotSupported"));
            else
                return cultureInfoHelper;
        }

        /// <summary>
        /// Retrieves a cached, read-only instance of a culture using the specified culture name.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="T:System.Globalization.CultureInfo"/> object.
        /// </returns>
        /// <param name="name">The name of a culture. <paramref name="name"/> is not case-sensitive.</param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.</exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="name"/> specifies a culture that is not supported.</exception>
        public static CultureInfo GetCultureInfo(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            CultureInfo cultureInfoHelper = CultureInfo.GetCultureInfoHelper(0, name, (string)null);
            if (cultureInfoHelper == null)
                throw new CultureNotFoundException("name", name, Environment.GetResourceString("Argument_CultureNotSupported"));
            else
                return cultureInfoHelper;
        }

        /// <summary>
        /// Retrieves a cached, read-only instance of a culture. Parameters specify a culture that is initialized with the <see cref="T:System.Globalization.TextInfo"/> and <see cref="T:System.Globalization.CompareInfo"/> objects specified by another culture.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="T:System.Globalization.CultureInfo"/> object.
        /// </returns>
        /// <param name="name">The name of a culture. <paramref name="name"/> is not case-sensitive.</param><param name="altName">The name of a culture that supplies the <see cref="T:System.Globalization.TextInfo"/> and <see cref="T:System.Globalization.CompareInfo"/> objects used to initialize <paramref name="name"/>. <paramref name="altName"/> is not case-sensitive.</param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> or <paramref name="altName"/> is null.</exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="name"/> or <paramref name="altName"/> specifies a culture that is not supported.</exception>
        public static CultureInfo GetCultureInfo(string name, string altName)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (altName == null)
                throw new ArgumentNullException("altName");
            CultureInfo cultureInfoHelper = CultureInfo.GetCultureInfoHelper(-1, name, altName);
            if (cultureInfoHelper != null)
                return cultureInfoHelper;
            throw new CultureNotFoundException("name or altName", string.Format((IFormatProvider)CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_OneOfCulturesNotSupported"), new object[2]
            {
                (object)name,
                (object)altName
            }));
        }

        /// <summary>
        /// Deprecated. Retrieves a read-only <see cref="T:System.Globalization.CultureInfo"/> object having linguistic characteristics that are identified by the specified RFC 4646 language tag.
        /// </summary>
        /// 
        /// <returns>
        /// A read-only <see cref="T:System.Globalization.CultureInfo"/> object.
        /// </returns>
        /// <param name="name">The name of a language as specified by the RFC 4646 standard.</param><exception cref="T:System.ArgumentNullException"><paramref name="name"/> is null.</exception><exception cref="T:System.Globalization.CultureNotFoundException"><paramref name="name"/> does not correspond to a supported culture.</exception>
        public static CultureInfo GetCultureInfoByIetfLanguageTag(string name)
        {
            if (name == "zh-CHT" || name == "zh-CHS")
            {
                throw new CultureNotFoundException("name", string.Format((IFormatProvider)CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_CultureIetfNotSupported"), new object[1]
                {
                    (object)name
                }));
            }
            else
            {
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo(name);
                if (cultureInfo.LCID <= (int)ushort.MaxValue && cultureInfo.LCID != 1034)
                    return cultureInfo;
                throw new CultureNotFoundException("name", string.Format((IFormatProvider)CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_CultureIetfNotSupported"), new object[1]
                {
                    (object)name
                }));
            }
        }

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static string nativeGetLocaleInfoEx(string localeName, uint field);

        [SecuritySafeCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static int nativeGetLocaleInfoExInt(string localeName, uint field);

        [SecurityCritical]
        [MethodImpl(MethodImplOptions.InternalCall)]
        internal static bool nativeSetThreadLocale(string localeName);

        private static bool Init()
        {
            if (CultureInfo.s_InvariantCultureInfo == null)
                CultureInfo.s_InvariantCultureInfo = new CultureInfo("", false)
                {
                    m_isReadOnly = true
                };
            CultureInfo.s_userDefaultCulture = CultureInfo.s_userDefaultUICulture = CultureInfo.s_InvariantCultureInfo;
            CultureInfo.s_userDefaultCulture = CultureInfo.InitUserDefaultCulture();
            CultureInfo.s_userDefaultUICulture = CultureInfo.InitUserDefaultUICulture();
            return true;
        }

        [SecuritySafeCritical]
        private static CultureInfo InitUserDefaultCulture()
        {
            string defaultLocaleName = CultureInfo.GetDefaultLocaleName(1024);
            if (defaultLocaleName == null)
            {
                defaultLocaleName = CultureInfo.GetDefaultLocaleName(2048);
                if (defaultLocaleName == null)
                    return CultureInfo.InvariantCulture;
            }
            CultureInfo cultureByName = CultureInfo.GetCultureByName(defaultLocaleName, true);
            cultureByName.m_isReadOnly = true;
            return cultureByName;
        }

        private static CultureInfo InitUserDefaultUICulture()
        {
            string defaultUiLanguage = CultureInfo.GetUserDefaultUILanguage();
            if (defaultUiLanguage == CultureInfo.UserDefaultCulture.Name)
                return CultureInfo.UserDefaultCulture;
            CultureInfo cultureByName = CultureInfo.GetCultureByName(defaultUiLanguage, true);
            if (cultureByName == null)
                return CultureInfo.InvariantCulture;
            cultureByName.m_isReadOnly = true;
            return cultureByName;
        }

        private void InitializeFromCultureId(int culture, bool useUserOverride)
        {
            switch (culture)
            {
                case 2048:
                case 3072:
                case 4096:
                case 0:
                case 1024:
                    throw new CultureNotFoundException("culture", culture, Environment.GetResourceString("Argument_CultureNotSupported"));
                default:
                    this.m_cultureData = CultureData.GetCultureData(culture, useUserOverride);
                    this.m_isInherited = this.GetType() != typeof(CultureInfo);
                    this.m_name = this.m_cultureData.CultureName;
                    break;
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext ctx)
        {
            if (this.m_name == null || CultureInfo.IsAlternateSortLcid(this.cultureID))
            {
                this.InitializeFromCultureId(this.cultureID, this.m_useUserOverride);
            }
            else
            {
                this.m_cultureData = CultureData.GetCultureData(this.m_name, this.m_useUserOverride);
                if (this.m_cultureData == null)
                    throw new CultureNotFoundException("m_name", this.m_name, Environment.GetResourceString("Argument_CultureNotSupported"));
            }
            this.m_isInherited = this.GetType() != typeof(CultureInfo);
            if (!(this.GetType().Assembly == typeof(CultureInfo).Assembly))
                return;
            if (this.textInfo != null)
                CultureInfo.CheckDomainSafetyObject((object)this.textInfo, (object)this);
            if (this.compareInfo == null)
                return;
            CultureInfo.CheckDomainSafetyObject((object)this.compareInfo, (object)this);
        }

        private static bool IsAlternateSortLcid(int lcid)
        {
            if (lcid == 1034)
                return true;
            else
                return (lcid & 983040) != 0;
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext ctx)
        {
            this.m_name = this.m_cultureData.CultureName;
            this.m_useUserOverride = this.m_cultureData.UseUserOverride;
            this.cultureID = this.m_cultureData.ILANGUAGE;
        }

        private static CultureInfo GetCultureByName(string name, bool userOverride)
        {
            try
            {
                return userOverride ? new CultureInfo(name) : CultureInfo.GetCultureInfo(name);
            }
            catch (ArgumentException ex)
            {
            }
            return (CultureInfo)null;
        }

        private void VerifyWritable()
        {
            if (this.m_isReadOnly)
                throw new InvalidOperationException(Environment.GetResourceString("InvalidOperation_ReadOnly"));
        }

        [SecurityCritical]
        private static string GetDefaultLocaleName(int localeType)
        {
            string s = (string)null;
            if (CultureInfo.InternalGetDefaultLocaleName(localeType, JitHelpers.GetStringHandleOnStack(ref s)))
                return s;
            else
                return string.Empty;
        }

        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        [DllImport("QCall", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool InternalGetDefaultLocaleName(int localetype, StringHandleOnStack localeString);

        [SecuritySafeCritical]
        private static string GetUserDefaultUILanguage()
        {
            string s = (string)null;
            if (CultureInfo.InternalGetUserDefaultUILanguage(JitHelpers.GetStringHandleOnStack(ref s)))
                return s;
            else
                return string.Empty;
        }

        [SecurityCritical]
        [SuppressUnmanagedCodeSecurity]
        [DllImport("QCall", CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool InternalGetUserDefaultUILanguage(StringHandleOnStack userDefaultUiLanguage);

        [SecuritySafeCritical]
        private static string GetSystemDefaultUILanguage()
        {
            string s = (string)null;
            if (CultureInfo.InternalGetSystemDefaultUILanguage(JitHelpers.GetStringHandleOnStack(ref s)))
                return s;
            else
                return string.Empty;
        }

        [SuppressUnmanagedCodeSecurity]
        [SecurityCritical]
        [DllImport("QCall", CharSet = CharSet.Unicode)]
        [MethodImpl(MethodImplOptions.InternalCall)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static bool InternalGetSystemDefaultUILanguage(StringHandleOnStack systemDefaultUiLanguage);
*/
    }
}
