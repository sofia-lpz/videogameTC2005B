### Entity-Relationship Diagram

#### Entities and Attributes:

1. **Player**
   - `username` (PK)
   - `password`

2. **Villager**
   - `villager_id` (PK)
   - `name`
   - `description`
   - `element`

3. **Card**
   - `cardId` (PK)
   - `name`
   - `energy_cost`
   - `effect`
   - `type`
   - `description`
   - `player_health`
   - `player_attack`
   - `player_defense`
   - `player_support`
   - `enemy_defense`
   - `enemy_attack`

4. **TCG_Match**
   - `matchId` (PK)
   - `timestamp`
   - `username` (FK to Player)
   - `won`

5. **Card_Use**
   - `cardId` (PK, FK to Card)
   - `username` (PK, FK to Player)
   - `times_used`

6. **Villager_Use**
   - `villager_id` (PK, FK to Villager)
   - `username` (PK, FK to Player)
   - `times_used`

7. **Stats**
   - `username` (PK, FK to Player)
   - `most_used_card` (FK to Card)
   - `most_used_villager` (FK to Villager)
   - `least_used_card` (FK to Card)
   - `least_used_villager` (FK to Villager)
   - `memories_found`
   - `matches_won`
   - `total_matches_played`

8. **Global_Stats**
   - `global_stats_id` (PK)
   - `most_used_card` (FK to Card)
   - `most_used_villager` (FK to Villager)
   - `least_used_card` (FK to Card)
   - `least_used_villager` (FK to Villager)
   - `memories_found_avg`

#### Relationships:

1. **Player - TCG_Match**: One-to-Many
   - A player can have multiple matches.
   - `username` in `TCG_Match` references `username` in `Player`.

2. **Player - Card_Use**: Many-to-Many
   - A player can use multiple cards.
   - A card can be used by multiple players.
   - `username` and `cardId` in `Card_Use` reference `username` in `Player` and `cardId` in `Card`.

3. **Player - Villager_Use**: Many-to-Many
   - A player can use multiple villagers.
   - A villager can be used by multiple players.
   - `username` and `villager_id` in `Villager_Use` reference `username` in `Player` and `villager_id` in `Villager`.

4. **Player - Stats**: One-to-One
   - Each player has one set of stats.
   - `username` in `Stats` references `username` in `Player`.

5. **Card - Stats**: Many-to-One
   - Many stats can refer to the same card as the most or least used.
   - `most_used_card` and `least_used_card` in `Stats` reference `cardId` in `Card`.

6. **Villager - Stats**: Many-to-One
   - Many stats can refer to the same villager as the most or least used.
   - `most_used_villager` and `least_used_villager` in `Stats` reference `villager_id` in `Villager`.

7. **Global_Stats - Card**: Many-to-One
   - Many global stats can refer to the same card.
   - `most_used_card` and `least_used_card` in `Global_Stats` reference `cardId` in `Card`.

8. **Global_Stats - Villager**: Many-to-One
   - Many global stats can refer to the same villager.
   - `most_used_villager` and `least_used_villager` in `Global_Stats` reference `villager_id` in `Villager`.
