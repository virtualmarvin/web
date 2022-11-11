# Database Design

The main entity is the user and the person that logs it. Data flows from this user as they will have subjects to be reminded about and events to be monitored and aware of.

## Example

### Wedding Anniversary

**User:** Bob  
**Subject:** Wedding Anniversary  
**Event:** 5th November (occurence 1 per year) 
**EventInstance:** 5th November 2022

### Date Night

**User:** Bob  
**Subject:** Date night with the wife  
**Event:** 25th December (once every two months)  
**EventInstance:** 25th December 2022  
**EventInstance:** 25th February 2023  

### Queries

```sql
SELECT events for a user
SELECT due events (using instance table) ORDER BY instance date desc
SELECT gift suggestions for event instances
INSERT gift suggestions based of suggestions
```

```mermaid
erDiagram
    USER ||--|{ SUBJECT : creates
    USER {
        uniqueidentifier id
        string name
    }
    USER ||--|{ EVENT : creates
    EVENT {
        uniqueidentifier id
        uniqueidentifier userid
        string name "Name of the event"
        date startdate
        int occurence "1"
        string interval "yearly|monthly|etc"
        string status
        bit deleted
    }
    EVENT ||--|{ EVENTINSTANCE : has
    EVENTINSTANCE {
        uniqueidentifier id
        date date
        string status
    }
    EVENTINSTANCE |o --o{ GIFTSUGGESTIONS : can-have
    GIFTSUGGESTIONS {
        uniqueidentifier id
        uniqueidentifier eventinstanceid
        uniqueidentifier giftid
        string rating
    }
    SUBJECT {
        uniqueidentifier id
        uniqueidentifier eventid
        string type
        date subjectdate "could be birthday"
        string status
        bit giftable
    }
    SUBJECT ||--o{ SUBJECTMETADATA : has
    SUBJECTMETADATA {
        uniqueidentifier id
        string gender
        string agerange
        string type "XMas|Birthday|Wedding"
    }
    GIFT ||--o{ GIFTMETA : has
    GIFT {
        uniqueidentifier id
        string name
        decimal targetprice
        string shopurl "eventually refactor our into own table"
    }
    GIFTMETA {
        uniqueidentifier id
        uniqueidentifier giftid
        string gendersuitability "m|f|b|jedi"
        string agesuitability "18-30"
        string type "XMas|Birthday|Wedding"
        string rating
    }
```
