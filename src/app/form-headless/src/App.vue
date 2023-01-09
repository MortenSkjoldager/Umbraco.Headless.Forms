<template>
  <div>
    <custom-form formName="Simple Form" />    
  </div>
</template>

<script>
import DynamicComponent from './components/dynamic-component.vue'
import CustomForm from './components/form.vue'
export default {
  name: 'App',
  components: {
    DynamicComponent,
    CustomForm 
  }
}
</script>

<style>

</style>
