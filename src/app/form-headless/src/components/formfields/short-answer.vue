<template>
    <input type="text" v-model="field.value" />
</template>

<script>

export default {
  name: 'ShortAnswer',
  props: {
    field: Object
  },
}
</script>
