import { eventEmitter } from 'AdminPanel/eventEmitter';
import { notificationEvent, NotificationMsg } from 'AdminPanel/components/molecules/Notification';


export function callNotification(data: NotificationMsg) {
  eventEmitter.emit<NotificationMsg>(notificationEvent, data);
}