using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ObserverPattern
{
    public interface ISubject
    {
        //������ ���
        void ResisterObserver(IObserver obsever);
        // ������ ����
        void RemoveObserver(IObserver observer);
        // �������鿡�� ���� ����
        void NotifyObservers();
    }

    public interface IObserver
    {
        // ����Ÿ�, ���ᷮ ���� ������Ʈ
        void UpdateData(float mileage, float amountFuel);
    }

    public class ObserverTest : MonoBehaviour, ISubject
    {
        private List<IObserver> list_Observers = new List<IObserver>();

        // ���ϸ��� ������
        private float mileage;

        // ���ᷮ ������
        private float fuelAmount;

        /// <summary>
        /// ������ ��� �Լ�.
        /// </summary>
        /// <param name="observer"></param>
        public void ResisterObserver(IObserver observer)
        {
            list_Observers.Add(observer);
        }

        /// <summary>
        /// ������ ���� �Լ�.
        /// </summary>
        /// <param name="observer"></param>
        public void RemoveObserver(IObserver observer)
        {
            list_Observers.Remove(observer);
        }

        /// <summary>
        /// �������鿡�� ���� ���� �Լ�
        /// </summary>
        public void NotifyObservers()
        {
            foreach(IObserver observer in list_Observers)
            {
                observer.UpdateData(mileage, fuelAmount);
            }
        }

        /// <summary>
        /// �ڵ��� ����Ʈ����κ��� ������Ʈ�� ������ �޴� �Լ�
        /// </summary>
        /// <param name="newMileage">���ŵ� ���ϸ��� ����.</param>
        /// <param name="newFuelAmount">���ŵ� ���ᷮ ����.</param>
        public void UpdataData(float newMileage, float newFuelAmount)
        {
            mileage = newMileage;
            fuelAmount = newFuelAmount;
            NotifyObservers();
        }
    }
}

