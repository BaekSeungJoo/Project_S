using ObserverPattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    public class ObserverTestUI : MonoBehaviour, IObserver
    {
        [SerializeField] ObserverTest data;
        [SerializeField] private Text txtMileage;
        [SerializeField] private Text txtAmountFuel;

        private void OnEnable()
        {
            // ������ �������� ���
            data.ResisterObserver(this);
        }

        private void OnDisable()
        {
            data.RemoveObserver(this);
        }

        /// <summary>
        /// ������ ���޹����� UI�� update �Ѵ�.
        /// </summary>
        /// <param name="mileage"></param>
        /// <param name="amountFuel"></param>
        public void UpdateData(float mileage, float amountFuel)
        {
            txtMileage.text = mileage.ToString();
            txtAmountFuel.text = amountFuel.ToString();
        }
    }
}

