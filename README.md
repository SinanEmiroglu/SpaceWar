# Space War
Rovio Code Challenge

**Playable APK:** [Space War](https://drive.google.com/file/d/1LSchbcBFNxCSfCUU7n_-VvB5mjt71vTi/view?usp=sharing)

## 1. Game Design
**Genre:** 2D Arcade-like Space Shooter

**Target Audience:** Mobile Game Players & Old-School Arcade Lovers

**Interaction Mode:** Single Player

**Camera Mode:** Top-down

**Hardware Platform:** Mobile Android

**Challenge:** Main challenge of the game is to stay alive while destroying the enemy ships and asteroids

**Game Rules:** The game has a win and a loss condition. Basically, the game is won when the desired score is achieved, and the game is lost when the player dies. Players can see their health and score values in the upper left corner of their screens. In addition, the game consists of three levels that are linearly connected. As levels are completed the next will respectively be unlocked. Since level data is generically designed, it is very easy to add new levels by creating new _Level Data_.

## 2. Game Elements
**Player:** Players can move their ships with the primary finger touch. When the game starts, the player's ship automatically starts firing. Also, players have two skills that they can use by pressing skill buttons on the left. These are missile, a rocket giving incredible damage, and a shield that can also heal the player periodically (one health per second). Missile skill has five seconds and shield skill has ten seconds cool-down.

**Enemies:** There are three different enemy ships that can use different weapons such as lasers or rockets in the game. Although they can use weapons in different formations, their mobility is the same.

**Asteroids & Rocks:** In addition, there are two large and two small asteroids. When large asteroids are destroyed, they split into small rock pieces and randomly scatter around. Asteroids and rocks can cause serious damage to players.

**Power-ups:** When any of the enemies or asteroids are destroyed, there are two different boosters can possibly be spawned. One of them heals the player while the other enhances the laser projectiles.

## 3. Technical Details
During the development process, SOLID principles were adopted as much as possible. However, it may not be necessary to use all principles at the same time, so I focused on the most necessary once for this small challenge. I think the single responsibility is a principle that should always be applied in every Unity project. Therefore, I tried to place all the logic in separate and related classes to create as abstract and reusable codes as possible. Besides, the observer model was used for a general weapon system. For example, any logic extended from "WeaponComponent" can override "WeaponFired()" action to utilize fire action generically. In this project, it is only used for projectile launching, yet the abstract structure of the system allows us to add any weapon action.

Interface integration principle could be used for damage and die mechanics. However, I chose a more modular structure that can be used as a component in the editor by making a separate health class. Nevertheless, I kept the interfaces in the "Interface" folder.

### 3.1. Imported Packages
**New Input System:** It was used the new input system to handle player ship movement and all other interactions.

There are two action maps: Player and UI for inputs
 1. Move Action: It’s a normalized 2D vector composite using the delta vectors of the primary touch and mouse position.
 2. UI Action Map: This map borrowed from default input system asset. Besides, the action asset of “EventSystem” was replaced with my version of input asset.

**Pooling & Spawning System:** I wrote these systems after I took an advanced Unity Mastery course more than a year ago. Any class extended from “PooledMonoBehaviour” can be pooled easily under a 'Pool' object in the scene. Each type has its own pool. For this challenge, they were refactored a little bit. Since the level scene is additively loaded, all pooled objects were instantiated in the main scene. Instead of that, an empty scene was created just for pooled objects. Besides, pooled objects are still remain enabled after level unload, so a returning all objects to pool method added to fix that issue.

For spawning system, instead of adding spawnable prefabs directly to the spawner objects in the level scene. I created “LevelData” to keep any kinds of spawnables for each specific level. Spawner are reading prefabs from level data after level loaded.

### 3.2. Code Architecture
**Game Manager:** It is a singleton class to manage loading levels and game results. In addition, the score property and the event handling are kept under this class.

**Level Data:** Level data were designed as scriptable objects, these data objects include how many points are required to win the corresponding level, what the next level will be to unlocked, and which objects will be spawn in the current level. These data are creating a diversity between the different levels.

**Game Objects with Components Attached:**

- Player Ship
  - Player : MonoBehaviour
  - PlayerMovementController : MonoBehaviour
  - Health : MonoBehaviour
  - MissileSkill : SkillBase
  - ShieldSkill : SkillBase
- Enemy Ships with 3 variants
  - Enemy : Spawnable
  - EnemyMovement : MonoBehaviour
  - Health : MonoBehaviour
  - Score : ImpactOnDie
- Big Asteroid with 2 variants
  - Asteroid : Spawnable
  - Health : MonoBehaviour
  - Score : ImpactOnDie
  - NonPlayerMover : MonoBehaviour
  - PowerOnDie : ImpactOnDie
- Rocks with 2 variants
  - Asteroid : Spawnable
  - Health : MonoBehaviour
  - Score : ImpactOnDie
  - NonPlayerMover : MonoBehaviour
- Skills
  - Missile : SkillBase
  - Shield : SkillBase
- Lasers & Rockets
  - Projectile : PooledMonoBehaviour
- Shield
  - Shield : PooledMonoBehaviour
- Powerups
  - PlayerHealer : Powerup
  - LaserEnhancer : Powerup
- UI Elements
  - Health Bar
  - Skill Bar
  - Score Text
  
### 3.3. Decisions Made
Before I started to design this simple space war/asteroid game, I downloaded some space shooters to see how people solve certain issues like movement and firing mechanics. As I thought, automatic laser firing is more engaging than putting a fire button. I decided to implement a similar approach so that players are not going to care about pressing fire button all the time. However, I preferred buttons for skills like a missile or a shield.

While developing any kind of project in Unity, I usually prefer to split each logic into separate modular classes. This approach allows me to handle dependencies and to extend project generically. However, it does not mean writing less code while using more classes makes the architecture much better. I experienced it is a quite good practice to do so in OOP. I saw a counter-example named Yandere Simulator which has thousands of lines codes with a lot of 'switch' cases and 'if' statemenets.

I also decided not to write lots of comments in scripts. Like Uncle Bob said, good written codes does not necessarily require comments because they are already  readable.

Finally, I wrote some unit tests for the healing and damage taking functionalities. I could have written more tests but I didn't want to exploit attributes or mocking them by utulizing a 3rd party library like Nsubstitude.

### 3.4. Challenges & Weaknesses
I think UI codding in Unity is a very vital issue because bad code can cause all game to stop. Moreover,  not only codding but the hierarchical order of canvases also might cause low frame-rates since UI batching heavily depends on CPU. When I was working in Finland, I experience a similar situation that UI made game unplayable after playing a couple of minutes. Unfortunately, developers created a placeholder UI by using nested canvases and UI elements included a lot of data objects and logic in it. Therefore, the most challenging part of development process is to decide what kind of architecture applied for UI. I spent quite some times to create something async; however, I couldn't tell I succeeded. So, I focus to create something simple, yet powerfull. Nevertheless, this is not a heavily UI dependent game. Instead, I preferred to divide the logic between UI and data. UI is used to display data when they are refreshed. So, my overall architecture for almost all projects benefits from action events so that I can subscribe then into the UI without touching any data logic. This method is more useful and robust than checking data in the Update function in every single frame. However, using events causes a serious problem if they are not unsubscribed after the objects are destroyed. In my experience, these are the most nasty issues since debugging and finding where the problem lies in. Fortunately, I already have a habit to care about all subscription after I dispatch them.

There is another way known static approach to bind data in UI scripts. It allows us to get attributes from anywhere since they are bounded with class not the instance itself. However, there might be some drawbacks to prefer this method. First, lifetime of static attributes are bounded with the lifetime of the running app. Which means when they are allocated in the memory, they will stay there until the app is closed even if we do not want to use them. Therefore, more static might cause more performance issues.

Another challenge I experience during the development was to handle all dependencies between different additive scenes. I preferred to use Singleton pattern to solve this problem. “GameManager” is a singleton class so it can be reach from other scene easily if script execution orders are considered properly. Another way to solve dependency management problems is to use dependency injection for Unity. I did not benefit it in this project.

Shield skill is not refreshing time after I used once. It took a couple of minutes to realize what it was causing this problem. Finally, I realized that base class is using update and I was using update in the sub-classes, so only sub-class's update was running not the base one that the cool-down refreshment should happen. One way to fix this problem is to override Unity methods. But I preferred to use only “LateUpdate” in the sub-class, so both are working now.

## 4. Last Comments
I really enjoyed while working on this small challenge. I could have done many things like adding more mechanics or polising visuals. However, I chose to stick with a relatively better architecture that can be scaled easily in the future. I am looking forward to see what other developers think about this humble work.
