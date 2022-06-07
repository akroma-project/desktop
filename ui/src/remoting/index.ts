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

receiveMessageInternal((msg: string) => {
  console.log(`Inside Remoting: ${msg}`);
});

export const sendMessage = (message: string) => {
  window.external.sendMessage(message);
};
