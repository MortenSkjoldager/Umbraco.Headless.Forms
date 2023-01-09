<template>
    <div>
        <select v-model="field.value">
            <option v-for="prevalue in field.preValues" :value="prevalue.value" :key="prevalue.value">{{prevalue.caption}}</option>
        </select>
    </div>
</template>

<script>

export default {
  name: 'Dropdown',
  props: {
    field: Object
  },
}
</script>
