import * as React from 'react';
import confetti from 'canvas-confetti';
import type { PiletApi } from 'app';

export default (app: PiletApi) => {
  // @ts-ignore
  window.fireConfetti = async function () {
    const settings = {
      particleCount: 3,
      scalar: 1.5,
      colors: ['#FFDE54', '#FF5A54', '#54FF90'],
      spread: 70,
    };
    const end = Date.now() + 1000;

    function frame() {
      confetti({
        ...settings,
        angle: 60,
        origin: { x: 0 },
      });
      confetti({
        ...settings,
        angle: 120,
        origin: { x: 1 },
      });

      if (Date.now() < end) {
        window.requestAnimationFrame(frame);
      }
    }

    frame();
  };
};
