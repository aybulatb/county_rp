type EventsStorage = {
  [key: string]: Function[];
}


class EventEmitter {
  events: EventsStorage;

  constructor() {
    this.events = {} as EventsStorage;
  }

  subscribe<T>(eventName: string, fn: (data: T) => void) {
    if (!this.events[eventName] ) {
      this.events[eventName] = [];
    }

    this.events[eventName].push(fn);

    return () => {
      this.events[eventName] = this.events[eventName].filter(eventFn => fn !== eventFn);
    }
  }

  emit<T>(eventName: string, data: T) {
    const event = this.events[eventName];
    
    if (event) {
      event.forEach(fn => {
        fn.call(null, data);
      });
    }
  }
}


export const eventEmitter = new EventEmitter();