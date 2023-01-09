<template>
  <div>
    <div>
        <span>{{field.title}}</span>
    </div>
    <component :is="field.alias" :field="field" />
  </div>
</template>

<script>
import * as components from './formfields/index'

export default {
  name: 'DynamicComponent',
  props: {
    field: Object
  },
  components: {
    ...components
  }
}
</script>
