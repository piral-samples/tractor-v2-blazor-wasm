import * as React from 'react';
import type { PiletApi } from 'app';

export default (app: PiletApi) => {
  // @ts-ignore
  window.openStorePicker = () => {
    // @ts-ignore
    document.querySelector('.e_StorePicker_dialog')?.showModal();
  };
};
