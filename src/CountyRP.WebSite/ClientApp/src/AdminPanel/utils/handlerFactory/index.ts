import { callNotification } from 'AdminPanel/utils/callNotification';


export function handlerFactory(service: () => Promise<number>, successCallback: () => void) {
  return async () => {
    try {
      const fetchResult = await service();

      if (fetchResult === 0) {
        successCallback();
        callNotification({
          header: '',
          content: 'изменения сохранены'
        })
      }
    } catch (error) {
      handlerFetchError(error);
      console.dir(error);
    }
  }
}

export function handlerFetchError(error: Error) {
  callNotification({
    header: 'Ошибка',
    content: error.message,
    type: 'error'
  })
}