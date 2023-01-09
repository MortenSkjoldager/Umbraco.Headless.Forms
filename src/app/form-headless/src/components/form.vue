<template>
    <div>
        <div v-if="this.form == null">
            <h1>Loading form...</h1>
        </div>
        <div v-if="this.form != null">
            <h1>{{this.form.name}}</h1>

            <div v-for="field in form.formFields" :key="field.caption">
                <div>
                    <dynamic-component :field="field" />
                </div>
            </div>

            <div v-for="field in form.formFields" :key="field.caption">
                <div>
                    <span>{{field.fieldAlias}} : {{field.value}}</span>
                </div>
            </div>    
        </div>

        <button @click="post">Post the form please</button>
    </div>
</template>

<script>

import axios from 'axios';
import dynamicComponent from './dynamic-component.vue';

export default {
  components: { dynamicComponent },
    
  name: 'CustomForm',
  props: {
    formName: String,
  },
  data() {
    return {
        form: null
    }
  },
  methods: {
    post() {
      axios.post('http://localhost:23509/umbraco/api/customforms/PostForm',
      this.form).then(response => {
        console.log(response);
      })
    }
  },
  async mounted() {
    axios.get(`http://localhost:23509/umbraco/api/customforms/get?formName=${this.formName}`).then(response => {
      this.form = response.data  
    });
  }
}
</script>
