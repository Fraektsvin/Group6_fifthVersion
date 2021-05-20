package com.example.applicationtier.models;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.sql.Date;
@NoArgsConstructor
@Data
public class DateTime {
   static private long TICKS_AT_EPOCH = 621355968000000000L;
   long ticks;
   public DateTime(long t) {
            ticks = t;
        }
        public DateTime(Date date) {
            ticks = TICKS_AT_EPOCH + 10000 * date.getTime();
        }

        static public DateTime fromJavaMillis(long millis)
        {
            return new DateTime(TICKS_AT_EPOCH + 10000 * millis);
        }

        public Date ToDate()
        {
            return new Date((ticks-TICKS_AT_EPOCH)/10000);
        }
}
