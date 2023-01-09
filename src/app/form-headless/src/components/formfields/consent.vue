<template>
    <input type="checkbox" v-model="field.value" />
</template>

<script>

export default {
  name: 'DataConsent',
  props: {
    field: Object
  },
}
</script>
