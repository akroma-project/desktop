<template>
  <div>
    <h1 class="text-center">{{ msg }}</h1>

    <p class="text-center">
      This is a Vue App served from a local web root. Click on the button below
      to send a message to the backend. It will respond and send a message back
      to the UI.
    </p>

    <button class="primary center" v-on:click="callDotNet()">Call .NET</button>
  </div>
</template>

<script lang="ts" setup>
import { defineProps } from "vue";
import { sendMessage } from "@/remoting";
defineProps<{ msg: string }>();

const callDotNet = () => {
  sendMessage(`{"Command":"testMsg","Data":"Hi .NET! 🤖"}`);
};

// receiveMessage((msg: string) => {
//   console.log(`Received message: ${msg}`);
// });
</script>
