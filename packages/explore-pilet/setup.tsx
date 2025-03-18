import * as React from 'react';
import type { PiletApi } from 'app';

export default (app: PiletApi) => {
  // @ts-ignore
  window.openStorePicker = () => {
    // @ts-ignore
    document.querySelector('.e_StorePicker_dialog')?.showModal();
  };
  // @ts-ignore
  window.closeStorePicker = (shopId: string) => {
    const content = document.querySelector(`div[data-shop=${shopId}`)?.innerHTML;
    // @ts-ignore
    document.querySelector('.e_StorePicker_dialog')?.close();
    return content;
  };
};
