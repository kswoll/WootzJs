using System.Text;

namespace System
{
    /// <summary>
    /// Represents a time interval.
    /// </summary>
    public struct TimeSpan
    {
        /// <summary>
        /// Represents the zero <see cref="T:System.TimeSpan"/> value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan Zero = new TimeSpan(0L);

        /// <summary>
        /// Represents the maximum <see cref="T:System.TimeSpan"/> value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan MaxValue = new TimeSpan(long.MaxValue);

        /// <summary>
        /// Represents the minimum <see cref="T:System.TimeSpan"/> value. This field is read-only.
        /// </summary>
        public static readonly TimeSpan MinValue = new TimeSpan(long.MinValue);

        /// <summary>
        /// Represents the number of ticks in 1 millisecond. This field is constant.
        /// </summary>
        public const long TicksPerMillisecond = 10000L;

        /// <summary>
        /// Represents the number of ticks in 1 second.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const long TicksPerSecond = 10000000L;

        /// <summary>
        /// Represents the number of ticks in 1 minute. This field is constant.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const long TicksPerMinute = 600000000L;

        /// <summary>
        /// Represents the number of ticks in 1 hour. This field is constant.
        /// </summary>
        /// <filterpriority>1</filterpriority>
        public const long TicksPerHour = 36000000000L;

        /// <summary>
        /// Represents the number of ticks in 1 day.  This field is constant.
        /// </summary>
        public const long TicksPerDay = 864000000000L;

        private const long HoursPerDay = 24;
        private const long MinutesPerHour = 60;
        private const long SecondsPerMinute = 60;
        private const long MillisecondsPerSecond = 1000;

        private readonly long ticks;

        public TimeSpan(long ticks) : this()
        {
            this.ticks = ticks;
        }

        /// <summary>
        /// Initializes a new <see cref="T:System.TimeSpan"/> to a specified number of hours, minutes, and seconds.
        /// </summary>
        /// <param name="hours">Number of hours. </param><param name="minutes">Number of minutes. </param><param name="seconds">Number of seconds. </param><exception cref="T:System.ArgumentOutOfRangeException">The parameters specify a <see cref="T:System.TimeSpan"/> value less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception>
        public TimeSpan(int hours, int minutes, int seconds)
        {
            ticks = hours*TicksPerHour + minutes*TicksPerMinute + seconds*TicksPerSecond;
        }

        /// <summary>
        /// Initializes a new <see cref="T:System.TimeSpan"/> to a specified number of days, hours, minutes, and seconds.
        /// </summary>
        /// <param name="days">Number of days. </param><param name="hours">Number of hours. </param><param name="minutes">Number of minutes. </param><param name="seconds">Number of seconds. </param><exception cref="T:System.ArgumentOutOfRangeException">The parameters specify a <see cref="T:System.TimeSpan"/> value less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception>
        public TimeSpan(int days, int hours, int minutes, int seconds)
        {
            ticks = days*TicksPerDay + hours*TicksPerHour + minutes*TicksPerMinute + seconds*TicksPerSecond;
        }

        /// <summary>
        /// Initializes a new <see cref="T:System.TimeSpan"/> to a specified number of days, hours, minutes, seconds, and milliseconds.
        /// </summary>
        /// <param name="days">Number of days. </param><param name="hours">Number of hours. </param><param name="minutes">Number of minutes. </param><param name="seconds">Number of seconds. </param><param name="milliseconds">Number of milliseconds. </param><exception cref="T:System.ArgumentOutOfRangeException">The parameters specify a <see cref="T:System.TimeSpan"/> value less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception>
        public TimeSpan(int days, int hours, int minutes, int seconds, int milliseconds)
        {
            ticks = days*TicksPerDay + hours*TicksPerHour + minutes*TicksPerMinute + seconds*TicksPerSecond + milliseconds*TicksPerMillisecond;
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> that represents a specified time, where the specification is in units of ticks.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents <paramref name="value"/>.
        /// </returns>
        /// <param name="value">A number of ticks that represent a time. </param><filterpriority>1</filterpriority>
        public static TimeSpan FromTicks(long value)
        {
            return new TimeSpan(value);
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> that represents a specified number of seconds, where the specification is accurate to the nearest millisecond.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents <paramref name="value"/>.
        /// </returns>
        /// <param name="value">A number of seconds, accurate to the nearest millisecond. </param><exception cref="T:System.OverflowException"><paramref name="value"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.PositiveInfinity"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.NegativeInfinity"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>. </exception><filterpriority>1</filterpriority>
        public static TimeSpan FromSeconds(double value)
        {
            return new TimeSpan((int)(value*TicksPerSecond));
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> that represents a specified number of hours, where the specification is accurate to the nearest millisecond.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents <paramref name="value"/>.
        /// </returns>
        /// <param name="value">A number of hours accurate to the nearest millisecond. </param><exception cref="T:System.OverflowException"><paramref name="value"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. -or-<paramref name="value"/> is <see cref="F:System.Double.PositiveInfinity"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.NegativeInfinity"/>.</exception><exception cref="T:System.ArgumentException"><paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>. </exception><filterpriority>1</filterpriority>
        public static TimeSpan FromHours(double value)
        {
            return new TimeSpan((int)(value*TicksPerHour));
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> that represents a specified number of days, where the specification is accurate to the nearest millisecond.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents <paramref name="value"/>.
        /// </returns>
        /// <param name="value">A number of days, accurate to the nearest millisecond. </param><exception cref="T:System.OverflowException"><paramref name="value"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. -or-<paramref name="value"/> is <see cref="F:System.Double.PositiveInfinity"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.NegativeInfinity"/>.</exception><exception cref="T:System.ArgumentException"><paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>. </exception><filterpriority>1</filterpriority>
        public static TimeSpan FromDays(double value)
        {
            return new TimeSpan((int)(value*TicksPerDay));
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> that represents a specified number of milliseconds.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents <paramref name="value"/>.
        /// </returns>
        /// <param name="value">A number of milliseconds. </param><exception cref="T:System.OverflowException"><paramref name="value"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.PositiveInfinity"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.NegativeInfinity"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>. </exception><filterpriority>1</filterpriority>
        public static TimeSpan FromMilliseconds(double value)
        {
            return new TimeSpan((int)(value*TicksPerMillisecond));
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> that represents a specified number of minutes, where the specification is accurate to the nearest millisecond.
        /// </summary>
        /// 
        /// <returns>
        /// An object that represents <paramref name="value"/>.
        /// </returns>
        /// <param name="value">A number of minutes, accurate to the nearest millisecond. </param><exception cref="T:System.OverflowException"><paramref name="value"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.PositiveInfinity"/>.-or-<paramref name="value"/> is <see cref="F:System.Double.NegativeInfinity"/>. </exception><exception cref="T:System.ArgumentException"><paramref name="value"/> is equal to <see cref="F:System.Double.NaN"/>. </exception><filterpriority>1</filterpriority>
        public static TimeSpan FromMinutes(double value)
        {
            return new TimeSpan((int)(value*TicksPerMinute));
        }


        /// <summary>
        /// Gets the number of ticks that represent the value of the current <see cref="T:System.TimeSpan"/> structure.
        /// </summary>
        /// 
        /// <returns>
        /// The number of ticks contained in this instance.
        /// </returns>
        public long Ticks
        {
            get { return ticks; }
        }

        /// <summary>
        /// Gets the days component of the time interval represented by the current <see cref="T:System.TimeSpan"/> structure.
        /// </summary>
        /// 
        /// <returns>
        /// The day component of this instance. The return value can be positive or negative.
        /// </returns>
        public int Days
        {
            get { return (int)(ticks/TicksPerDay); }
        }

        /// <summary>
        /// Gets the hours component of the time interval represented by the current <see cref="T:System.TimeSpan"/> structure.
        /// </summary>
        /// 
        /// <returns>
        /// The hour component of the current <see cref="T:System.TimeSpan"/> structure. The return value ranges from -23 through 23.
        /// </returns>
        public int Hours
        {
            get { return (int)(ticks/TicksPerDay%HoursPerDay); }
        }

        /// <summary>
        /// Gets the milliseconds component of the time interval represented by the current <see cref="T:System.TimeSpan"/> structure.
        /// </summary>
        /// 
        /// <returns>
        /// The millisecond component of the current <see cref="T:System.TimeSpan"/> structure. The return value ranges from -999 through 999.
        /// </returns>
        public int Milliseconds
        {
            get { return (int)(ticks/TicksPerMillisecond%MillisecondsPerSecond); }
        }

        /// <summary>
        /// Gets the minutes component of the time interval represented by the current <see cref="T:System.TimeSpan"/> structure.
        /// </summary>
        /// 
        /// <returns>
        /// The minute component of the current <see cref="T:System.TimeSpan"/> structure. The return value ranges from -59 through 59.
        /// </returns>
        public int Minutes
        {
            get { return (int)(ticks/TicksPerMinute%MinutesPerHour); }
        }

        /// <summary>
        /// Gets the seconds component of the time interval represented by the current <see cref="T:System.TimeSpan"/> structure.
        /// </summary>
        /// 
        /// <returns>
        /// The second component of the current <see cref="T:System.TimeSpan"/> structure. The return value ranges from -59 through 59.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public int Seconds
        {
            get { return (int)(ticks/TicksPerSecond%SecondsPerMinute); }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.TimeSpan"/> structure expressed in whole and fractional days.
        /// </summary>
        /// 
        /// <returns>
        /// The total number of days represented by this instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public double TotalDays
        {
            get { return (double)ticks/TicksPerDay; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.TimeSpan"/> structure expressed in whole and fractional hours.
        /// </summary>
        /// 
        /// <returns>
        /// The total number of hours represented by this instance.
        /// </returns>
        public double TotalHours
        {
            get { return (double)ticks/TicksPerHour; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.TimeSpan"/> structure expressed in whole and fractional milliseconds.
        /// </summary>
        /// 
        /// <returns>
        /// The total number of milliseconds represented by this instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public double TotalMilliseconds
        {
            get { return (double)ticks/TicksPerMillisecond; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.TimeSpan"/> structure expressed in whole and fractional minutes.
        /// </summary>
        /// 
        /// <returns>
        /// The total number of minutes represented by this instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public double TotalMinutes
        {
            get { return (double)ticks/TicksPerMinute; }
        }

        /// <summary>
        /// Gets the value of the current <see cref="T:System.TimeSpan"/> structure expressed in whole and fractional seconds.
        /// </summary>
        /// 
        /// <returns>
        /// The total number of seconds represented by this instance.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public double TotalSeconds
        {
            get { return (double)ticks*TicksPerSecond; }
        }

        /// <summary>
        /// Returns a new <see cref="T:System.TimeSpan"/> object whose value is the sum of the specified <see cref="T:System.TimeSpan"/> object and this instance.
        /// </summary>
        /// 
        /// <returns>
        /// A new object that represents the value of this instance plus the value of <paramref name="ts"/>.
        /// </returns>
        /// <param name="ts">The time interval to add.</param><exception cref="T:System.OverflowException">The resulting <see cref="T:System.TimeSpan"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception><filterpriority>1</filterpriority>
        public TimeSpan Add(TimeSpan ts)
        {
            long ticks = this.ticks + ts.ticks;
            return new TimeSpan(ticks);
        }

        /// <summary>
        /// Returns a new <see cref="T:System.TimeSpan"/> object whose value is the difference between the specified <see cref="T:System.TimeSpan"/> object and this instance.
        /// </summary>
        /// 
        /// <returns>
        /// A new time interval whose value is the result of the value of this instance minus the value of <paramref name="ts"/>.
        /// </returns>
        /// <param name="ts">The time interval to be subtracted. </param><exception cref="T:System.OverflowException">The return value is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception><filterpriority>1</filterpriority>
        public TimeSpan Subtract(TimeSpan ts)
        {
            return new TimeSpan(ticks - ts.ticks);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// 
        /// <returns>
        /// A 32-bit signed integer hash code.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        public override int GetHashCode()
        {
            return (int)ticks ^ (int)(ticks >> 32);
        }

        /// <summary>
        /// Returns a value that indicates whether two specified instances of <see cref="T:System.TimeSpan"/> are equal.
        /// </summary>
        /// 
        /// <returns>
        /// true if the values of <paramref name="t1"/> and <paramref name="t2"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare. </param><param name="t2">The second time interval to compare. </param><filterpriority>1</filterpriority>
        public static bool Equals(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks == t2.ticks;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified <see cref="T:System.TimeSpan"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// true if <paramref name="obj"/> represents the same time interval as this instance; otherwise, false.
        /// </returns>
        /// <param name="obj">An object to compare with this instance. </param><filterpriority>1</filterpriority>
        public bool Equals(TimeSpan obj)
        {
            return ticks == obj.ticks;
        }

        /// <summary>
        /// Returns a value indicating whether this instance is equal to a specified object.
        /// </summary>
        /// 
        /// <returns>
        /// true if <paramref name="value"/> is a <see cref="T:System.TimeSpan"/> object that represents the same time interval as the current <see cref="T:System.TimeSpan"/> structure; otherwise, false.
        /// </returns>
        /// <param name="value">An object to compare with this instance. </param><filterpriority>1</filterpriority>
        public override bool Equals(object value)
        {
            if (value is TimeSpan)
                return ticks == ((TimeSpan)value).ticks;
            else
                return false;
        }

        /// <summary>
        /// Returns a new <see cref="T:System.TimeSpan"/> object whose value is the absolute value of the current <see cref="T:System.TimeSpan"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A new object whose value is the absolute value of the current <see cref="T:System.TimeSpan"/> object.
        /// </returns>
        /// <exception cref="T:System.OverflowException">The value of this instance is <see cref="F:System.TimeSpan.MinValue"/>. </exception><filterpriority>1</filterpriority>
        public TimeSpan Duration()
        {
            return new TimeSpan(ticks >= 0L ? ticks : -ticks);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="T:System.TimeSpan"/> object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the <see cref="T:System.TimeSpan"/> object.
        /// </summary>
        /// 
        /// <returns>
        /// A signed number indicating the relative values of this instance and <paramref name="value"/>.Value Description A negative integer This instance is shorter than <paramref name="value"/>. Zero This instance is equal to <paramref name="value"/>. A positive integer This instance is longer than <paramref name="value"/>.
        /// </returns>
        /// <param name="value">An object to compare to this instance.</param>
        public int CompareTo(TimeSpan value)
        {
            long num = value.ticks;
            if (ticks > num)
                return 1;
            return ticks < num ? -1 : 0;
        }

        /// <summary>
        /// Compares this instance to a specified object and returns an integer that indicates whether this instance is shorter than, equal to, or longer than the specified object.
        /// </summary>
        /// 
        /// <returns>
        /// One of the following values.Value Description -1 This instance is shorter than <paramref name="value"/>. 0 This instance is equal to <paramref name="value"/>. 1 This instance is longer than <paramref name="value"/>.-or- <paramref name="value"/> is null.
        /// </returns>
        /// <param name="value">An object to compare, or null. </param><exception cref="T:System.ArgumentException"><paramref name="value"/> is not a <see cref="T:System.TimeSpan"/>. </exception><filterpriority>1</filterpriority>
        public int CompareTo(object value)
        {
            if (value == null)
                return 1;
            if (!(value is TimeSpan))
                throw new ArgumentException("Argument must be a TimeSpan");
            var num = ((TimeSpan)value).ticks;
            if (ticks > num)
                return 1;
            return ticks < num ? -1 : 0;
        }

        /// <summary>
        /// Compares two <see cref="T:System.TimeSpan"/> values and returns an integer that indicates whether the first value is shorter than, equal to, or longer than the second value.
        /// </summary>
        /// 
        /// <returns>
        /// One of the following values.Value Description -1 <paramref name="t1"/> is shorter than <paramref name="t2"/>. 0 <paramref name="t1"/> is equal to <paramref name="t2"/>. 1 <paramref name="t1"/> is longer than <paramref name="t2"/>.
        /// </returns>
        /// <param name="t1">The first time interval to compare. </param><param name="t2">The second time interval to compare. </param><filterpriority>1</filterpriority>
        public static int Compare(TimeSpan t1, TimeSpan t2)
        {
            if (t1.ticks > t2.ticks)
                return 1;
            return t1.ticks < t2.ticks ? -1 : 0;
        }

        /// <summary>
        /// Returns a <see cref="T:System.TimeSpan"/> whose value is the negated value of the specified instance.
        /// </summary>
        /// 
        /// <returns>
        /// An object that has the same numeric value as this instance, but the opposite sign.
        /// </returns>
        /// <param name="t">The time interval to be negated. </param><exception cref="T:System.OverflowException">The negated value of this instance cannot be represented by a <see cref="T:System.TimeSpan"/>; that is, the value of this instance is <see cref="F:System.TimeSpan.MinValue"/>. </exception><filterpriority>3</filterpriority>
        public static TimeSpan operator -(TimeSpan t)
        {
            return new TimeSpan(-t.ticks);
        }

        /// <summary>
        /// Subtracts a specified <see cref="T:System.TimeSpan"/> from another specified <see cref="T:System.TimeSpan"/>.
        /// </summary>
        /// 
        /// <returns>
        /// An object whose value is the result of the value of <paramref name="t1"/> minus the value of <paramref name="t2"/>.
        /// </returns>
        /// <param name="t1">The minuend. </param><param name="t2">The subtrahend. </param><exception cref="T:System.OverflowException">The return value is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception><filterpriority>3</filterpriority>
        public static TimeSpan operator -(TimeSpan t1, TimeSpan t2)
        {
            return t1.Subtract(t2);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="T:System.TimeSpan"/>.
        /// </summary>
        /// 
        /// <returns>
        /// The time interval specified by <paramref name="t"/>.
        /// </returns>
        /// <param name="t">The time interval to return. </param><filterpriority>3</filterpriority>
        public static TimeSpan operator +(TimeSpan t)
        {
            return t;
        }

        /// <summary>
        /// Adds two specified <see cref="T:System.TimeSpan"/> instances.
        /// </summary>
        /// 
        /// <returns>
        /// An object whose value is the sum of the values of <paramref name="t1"/> and <paramref name="t2"/>.
        /// </returns>
        /// <param name="t1">The first time interval to add. </param><param name="t2">The second time interval to add.</param><exception cref="T:System.OverflowException">The resulting <see cref="T:System.TimeSpan"/> is less than <see cref="F:System.TimeSpan.MinValue"/> or greater than <see cref="F:System.TimeSpan.MaxValue"/>. </exception><filterpriority>3</filterpriority>
        public static TimeSpan operator +(TimeSpan t1, TimeSpan t2)
        {
            return t1.Add(t2);
        }

        /// <summary>
        /// Indicates whether two <see cref="T:System.TimeSpan"/> instances are equal.
        /// </summary>
        /// 
        /// <returns>
        /// true if the values of <paramref name="t1"/> and <paramref name="t2"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare. </param><param name="t2">The second time interval to compare. </param><filterpriority>3</filterpriority>
        public static bool operator ==(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks == t2.ticks;
        }

        /// <summary>
        /// Indicates whether two <see cref="T:System.TimeSpan"/> instances are not equal.
        /// </summary>
        /// 
        /// <returns>
        /// true if the values of <paramref name="t1"/> and <paramref name="t2"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare.</param><param name="t2">The second time interval to compare.</param><filterpriority>3</filterpriority>
        public static bool operator !=(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks != t2.ticks;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:System.TimeSpan"/> is less than another specified <see cref="T:System.TimeSpan"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the value of <paramref name="t1"/> is less than the value of <paramref name="t2"/>; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare.</param><param name="t2">The second time interval to compare. </param><filterpriority>3</filterpriority>
        public static bool operator <(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks < t2.ticks;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:System.TimeSpan"/> is less than or equal to another specified <see cref="T:System.TimeSpan"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the value of <paramref name="t1"/> is less than or equal to the value of <paramref name="t2"/>; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare. </param><param name="t2">The second time interval to compare. </param><filterpriority>3</filterpriority>
        public static bool operator <=(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks <= t2.ticks;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:System.TimeSpan"/> is greater than another specified <see cref="T:System.TimeSpan"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the value of <paramref name="t1"/> is greater than the value of <paramref name="t2"/>; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare. </param><param name="t2">The second time interval to compare. </param><filterpriority>3</filterpriority>
        public static bool operator >(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks > t2.ticks;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="T:System.TimeSpan"/> is greater than or equal to another specified <see cref="T:System.TimeSpan"/>.
        /// </summary>
        /// 
        /// <returns>
        /// true if the value of <paramref name="t1"/> is greater than or equal to the value of <paramref name="t2"/>; otherwise, false.
        /// </returns>
        /// <param name="t1">The first time interval to compare.</param><param name="t2">The second time interval to compare.</param><filterpriority>3</filterpriority>
        public static bool operator >=(TimeSpan t1, TimeSpan t2)
        {
            return t1.ticks >= t2.ticks;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            if (Days > 0)
                builder.Append(Days + ".");
            if (Hours < 10)
                builder.Append("0");
            builder.Append(Hours);
            if (Minutes < 10)
                builder.Append("0");
            builder.Append(Minutes);
            if (Seconds < 10)
                builder.Append("0");
            builder.Append(Seconds);
            if (Milliseconds > 0)
            {
                builder.Append(".");
                if (Milliseconds < 100)
                    builder.Append("0");
                if (Milliseconds < 10)
                    builder.Append("0");
                builder.Append(Milliseconds);
            }
            var remainingTicks = Ticks % TicksPerMillisecond;
            if (remainingTicks > 0)
            {
                if (remainingTicks < 1000)
                    builder.Append("0");
                if (remainingTicks < 100)
                    builder.Append("0");
                if (remainingTicks < 10)
                    builder.Append("0");
                builder.Append(remainingTicks);
            }
            return builder.ToString();
        }
    }
}