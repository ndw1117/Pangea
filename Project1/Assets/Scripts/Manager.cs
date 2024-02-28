using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    [SerializeField]
    GameObject music;

    [SerializeField]
    SpriteInfo player;

    [SerializeField]
    int health = 3;

    [SerializeField]
    GameObject health_panel;

    [SerializeField]
    GameObject meteor;

    [SerializeField]
    GameObject predator;

    [SerializeField]
    GameObject scoreText;

    [SerializeField]
    GameObject gameOverText;

    AudioSource[] tracks;

    int score = 0;
    int killBoost = 100; //The amount to increase the score every time an enemy is destroyed
    int dodgeBoost = 75; //The amount to increase the score every time an enemy leaves the screen without making contact with player

    List<GameObject> projectiles = new List<GameObject>();
    List<GameObject> meteors = new List<GameObject>();
    List<GameObject> predators = new List<GameObject>();

    int i = 0;

    int j = 0;

    //Responsible for a delay in the calling of SpawnMeteors
    float spawnTimerM = 2f;

    //Respoinsible for a delay in the calling of SpawnPredators
    float spawnTimerP = 2f;

    // Start is called before the first frame update
    void Start()
    {
        tracks = music.GetComponents<AudioSource>();
        tracks[0].Play();

        spawnTimerM = 2f;
        spawnTimerP = 2f;

        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if each meteor is touching the player or a projectile
        for (i = 0; i < meteors.Count; i++)
        {
            SpriteInfo meteorSprite = meteors[i].GetComponent<SpriteInfo>();

            if (CircleCollisionCheck(player, meteorSprite))
            {
                Destroy(meteorSprite.gameObject);
                meteors.RemoveAt(i);
                if (health > 0)
                {
                    health -= 1;
                    Destroy(health_panel.transform.GetChild(0).gameObject);
                    //health_panel.transform.GetChild(0).gameObject.SetActive(false);
                    if (health <= 0)
                    {
                        GameOver();
                    }
                }
                continue;
            }

            for (j = 0; j < projectiles.Count; j++)
            {
                if(CircleCollisionCheck(meteorSprite, projectiles[j].GetComponent<SpriteInfo>()))
                {
                    Destroy(meteorSprite.gameObject);
                    meteors.RemoveAt(i);

                    Destroy(projectiles[j]);
                    projectiles.RemoveAt(j);

                    score += killBoost;
                    break;
                }
            }
        }

        //Checks to see if each predator is touching the player or a projectile
        for (i = 0; i < predators.Count; i++)
        {
            SpriteInfo predatorSprite = predators[i].GetComponent<SpriteInfo>();

            if (CircleCollisionCheck(player, predatorSprite))
            {
                Destroy(predatorSprite.gameObject);
                predators.RemoveAt(i);
                if (health > 0)
                {
                    health -= 1;
                    Destroy(health_panel.transform.GetChild(0).gameObject);
                    //health_panel.transform.GetChild(0).gameObject.SetActive(false);
                    if (health <= 0)
                    {
                        GameOver();
                    }
                }
                continue;
            }

            for (j = 0; j < projectiles.Count; j++)
            {
                if (CircleCollisionCheck(predatorSprite, projectiles[j].GetComponent<SpriteInfo>()))
                {
                    Destroy(predatorSprite.gameObject);
                    predators.RemoveAt(i);

                    Destroy(projectiles[j]);
                    projectiles.RemoveAt(j);

                    score += killBoost;
                    break;
                }
            }
        }

        //Checks to see if each meteor is off the screen
        for (i = 0; i < meteors.Count; i++)
        {
            Meteor meteorObject = meteors[i].GetComponent<Meteor>();

            if (meteorObject.isOut())
            {
                Destroy(meteorObject.gameObject);
                meteors.RemoveAt(i);
                score += dodgeBoost;
            }
        }

        //Checks to see if each predator is off the screen
        for (i = 0; i < predators.Count; i++)
        {
            Predator predatorObject = predators[i].GetComponent<Predator>();

            if (predatorObject.isOut())
            {
                Destroy(predatorObject.gameObject);
                predators.RemoveAt(i);
                score += dodgeBoost;
            }
        }

        //Checks to see if each projectile is off the screen
        for (i = 0; i < projectiles.Count; i++)
        {
            Projectile projectile = projectiles[i].GetComponent<Projectile>();

            if(projectile.isOut())
            {
                Destroy(projectile.gameObject);
                projectiles.RemoveAt(i);
            }
        }

        //This handles the delay in calling SpawnMeteors
        if (spawnTimerM > 0f)
        {
            spawnTimerM -= Time.deltaTime;
        }
        
        if (spawnTimerM <= 0f)
        {
            SpawnMeteors();
            spawnTimerM = 2f;
        }

        //This handles the delay in calling SpawnPredators
        if (spawnTimerP > 0f)
        {
            spawnTimerP -= Time.deltaTime;
        }

        if (spawnTimerP <= 0f)
        {
            SpawnPredators();
            spawnTimerP = 2f;
        }

        //Update the score
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();

    }

    void SpawnMeteors()
    {
        float randValue = Random.Range(0, 100);     //Giving Range floats is inclusive, giving integers is exclusive of max value

        //Debug.Log(randValue);

        if (randValue < 59)     //60% Chance of spawning meteor on each update
        {
            meteors.Add(Instantiate(meteor, new Vector3(Random.Range(-11f, 8f), 6, 0), Quaternion.identity));
        }

    }

    void SpawnPredators()
    {
        float randValue = Random.Range(0, 100);     

        //Debug.Log(randValue);

        if (randValue < 59)     //60% Chance of spawning predator on each update
        {
            predators.Add(Instantiate(predator, new Vector3(-13, Random.Range(-5f, 5f), 0), Quaternion.identity));
        }
    }

    public void AddProjectile(GameObject projectile)
    {
        projectiles.Add(projectile);
    }

    bool CircleCollisionCheck(SpriteInfo objA, SpriteInfo objB) //Checks whether circle for objA is touching circle for objB
    {
        if (Mathf.Pow(objA.radius + objB.radius, 2) > (Mathf.Pow(objA.gameObject.transform.position.x - objB.gameObject.transform.position.x, 2) + Mathf.Pow(objA.gameObject.transform.position.y - objB.gameObject.transform.position.y, 2)))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    void GameOver()
    {
        //Make sure the final score is fully up to date
        scoreText.GetComponent<Text>().text = "Score: " + score.ToString();

        AudioSource[] tracks = music.GetComponents<AudioSource>();
        tracks[0].Stop();
        tracks[1].Play();

        gameOverText.SetActive(true);
        player.gameObject.SetActive(false);

        for (i = 0; i < projectiles.Count; i++)
        {
            Destroy(projectiles[i]);
        }

        for (i = 0; i < meteors.Count; i++)
        {
            Destroy(meteors[i]);
        }

        for (i = 0; i < predators.Count; i++)
        {
            Destroy(predators[i]);
        }

        this.gameObject.SetActive(false);
    }
}
