using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEditor;

namespace Test
{
    public class PlayerStateTests
    {
        float timeCounter = 0f;


        public IEnumerator CheckPlayerState(System.Type type, GameManager.PlayerStates state)
        {
            GameManager gameManager = new GameObject().AddComponent<GameManager>();
            GameObject player = GameObject.Instantiate(Resources.Load("Zombie")) as GameObject;

            PlayerState playerState = player.GetComponent<PlayerState>();

            //SE ESPERA 1 SEGUNDO
            timeCounter = 0f;
            while (timeCounter < 1) { timeCounter += Time.deltaTime; yield return null; }

            //COMPROBAR QUE EL ESTADO INICIAL DEL JUGADOR SEA EL ESTADO NEUTRO.
            Assert.IsInstanceOf(typeof(NoBadState), playerState.getState());

            //CAMBIAR SU ESTADO A GRAVITYINVSTATE
            gameManager.setGoingState(state);

            //SE ESPERA 1 SEGUNDO
            timeCounter = 0f;
            while (timeCounter < 1) { timeCounter += Time.deltaTime; yield return null; }

            //COMPROBAR QUE EL ESTADO DEL JUGADOR SEA EL ESTADO GRAVITYINVSTATE.
            Assert.IsInstanceOf(type, playerState.getState());

            //SE ESPERA 3 SEGUNDOS MAS
            timeCounter = 0f;
            while (timeCounter < 3) { timeCounter += Time.deltaTime; yield return null; }

            //COMPROBAR QUE PASADOS UNOS SEGUNDOS EL ESTADO VUELVE A SER EL ESTADO NEUTRO
            Assert.IsInstanceOf(typeof(NoBadState), playerState.getState());


            GameObject.Destroy(gameManager);
            GameObject.Destroy(player);
        }


        [UnityTest]
        public IEnumerator PlayerStateGravity()
        {
            return CheckPlayerState(typeof(GravityInvState), GameManager.PlayerStates.GravityInvState);
        }

        [UnityTest]
        public IEnumerator PlayerStateSlowed()
        {
            return CheckPlayerState(typeof(SlowedState), GameManager.PlayerStates.SlowedState);
        }

        [UnityTest]
        public IEnumerator PlayerStateControlInv()
        {
            return CheckPlayerState(typeof(ControlInvState), GameManager.PlayerStates.ControlInvState);
        }
    }
}
