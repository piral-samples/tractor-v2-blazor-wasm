import * as React from 'react';
import { createRoot } from 'react-dom/client';
import { Route } from 'react-router-dom';
import { createInstance, Piral } from 'piral-core';
import { createBlazorApi } from 'piral-blazor';
import { ScrollToTop } from './ScrollToTop';
import { layout, errors } from './layout';

const feedUrl = 'https://feed.piral.cloud/api/v1/pilet/tractor-v2-blazor-wasm-demo';
const root = createRoot(document.querySelector('#app'));

const instance = createInstance({
  state: {
    components: layout,
    errorComponents: errors,
  },
  plugins: [createBlazorApi({ lazy: false })],
  requestPilets() {
    return fetch(feedUrl)
      .then((res) => res.json())
      .then((res) => res.items);
  },
});

root.render(
  <Piral instance={instance}>
    <Route component={ScrollToTop} />
  </Piral>,
);
