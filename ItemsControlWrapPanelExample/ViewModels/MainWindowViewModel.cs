using ItemsControlWrapPanelExample.Models;
using DynamicData;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;


namespace ItemsControlWrapPanelExample.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private CityEvent cItem;
        private CityEvent[] sourceArray;
        private SourceList<CityEvent> sourceList;
        private readonly ReadOnlyObservableCollection<CityEvent> childrenEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> sportEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> cultureEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> excursionEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> lifestyleEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> partyEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> educationEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> onlineEvents;
        private readonly ReadOnlyObservableCollection<CityEvent> showEvents;

        public MainWindowViewModel()
        {
            sourceList = new SourceList<CityEvent>();
            sourceArray = Serializer<CityEvent[]>.Load("../../../CityEvents.xml");
            sourceList = new SourceList<CityEvent>();
            System.Diagnostics.Debug.WriteLine(sourceArray[0].Header, "\n");

            foreach (CityEvent cityEvent in sourceArray)
            {
                sourceList.Add(cityEvent);
            }

            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Для детей").ObserveOn(RxApp.MainThreadScheduler).Bind(out childrenEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Спорт").ObserveOn(RxApp.MainThreadScheduler).Bind(out sportEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Культура").ObserveOn(RxApp.MainThreadScheduler).Bind(out cultureEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Экскурсии").ObserveOn(RxApp.MainThreadScheduler).Bind(out excursionEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Образ жизни").ObserveOn(RxApp.MainThreadScheduler).Bind(out lifestyleEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Вечеринки").ObserveOn(RxApp.MainThreadScheduler).Bind(out partyEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Образование").ObserveOn(RxApp.MainThreadScheduler).Bind(out educationEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Онлайн").ObserveOn(RxApp.MainThreadScheduler).Bind(out onlineEvents).Subscribe();
            sourceList.Connect().AutoRefresh(x => x.Category).Filter(x => x.Category == "Шоу").ObserveOn(RxApp.MainThreadScheduler).Bind(out showEvents).Subscribe();
        }

        public CityEvent CItem
        {
            get => cItem;
            set => cItem = value;
        }
        public SourceList<CityEvent> SourceList
        {
            get => sourceList;
            set => this.RaiseAndSetIfChanged(ref sourceList, value);
        }

        public ReadOnlyObservableCollection<CityEvent> ChildrenEvents => childrenEvents;
        public ReadOnlyObservableCollection<CityEvent> SportEvents => sportEvents;
        public ReadOnlyObservableCollection<CityEvent> CultureEvents => cultureEvents;
        public ReadOnlyObservableCollection<CityEvent> ExcursionEvents => excursionEvents;
        public ReadOnlyObservableCollection<CityEvent> LifestyleEvents => lifestyleEvents;
        public ReadOnlyObservableCollection<CityEvent> PartyEvents => partyEvents;
        public ReadOnlyObservableCollection<CityEvent> EducationEvents => educationEvents;
        public ReadOnlyObservableCollection<CityEvent> OnlineEvents => onlineEvents;
        public ReadOnlyObservableCollection<CityEvent> ShowEvents => showEvents;
    }
}