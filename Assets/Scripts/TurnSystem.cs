using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CombatState { START, PLAYERGO, ENEMYGO, WONFIGHT, LOSTFIGHT }

public class TurnSystem : MonoBehaviour
{

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform playerZone;
    public Transform enemyZone;

    public CombatState state;
    
    void Start()
    {
        state = CombatState.START;
        StartCoroutine(SetupFight());
    }

    IEnumerator SetupFight()
    {
        GameObject playerGameObject = Instantiate(playerPrefab, playerZone);
        playerGameObject.GetComponent<Player>();
        
        GameObject enemyGameObject = Instantiate(enemyPrefab, enemyZone);
        enemyGameObject.GetComponent<Unit>();

        yield return new WaitForSeconds(2f);

        state = CombatState.PLAYERGO;
        PlayerGo();
    }

    IEnumerator PlayerAttackOption()
    {
        //enemyGameObject.GetComponent.<Unit>(playerGameObject.GetComponent.damage);

        yield return new WaitForSeconds(2f);
    }

    void PlayerGo()
    {
        if (state != CombatState.PLAYERGO)
            return;

        //if (TurnTimer.countdownTimer = 0)
        //{
            //state = CombatState.ENEMYGO;
            //EnemyGo();
        //}
    }

    void EnemyGo()
    {

    }
}
