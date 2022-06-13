declare global {
  interface External {
    sendMessage: (message: string) => void;
    receiveMessage: (delegate: (message: string) => void) => void;
  }

  interface Window {
    External: object;
  }
}

const receiveMessageInternal = window.external.receiveMessage;

if (receiveMessageInternal) {
  receiveMessageInternal((msg: string) => {
    console.log(`Inside Remoting: ${msg}`);
  });
}

export const sendMessage = (message: string) => {
  if (window.external.sendMessage) {
    window.external.sendMessage(message);
  } else {
    console.debug(`sendMessage is not defined: ${message}`);
  }
};
