<template>
  <div>
    <v-container>
      <v-row dense>
        <v-col v-for="(quest, i) in questions" :key="quest.id" cols="12">
          <v-card :color="colorQuestion" dark>
            <v-list-item>
              <v-list-item-avatar color="indigo">
                <h2>{{i+1}}</h2>
              </v-list-item-avatar>
              <v-list-item-content class="title text-justify">{{quest.text}}</v-list-item-content>
            </v-list-item>

            <v-card-actions>
              <v-btn large icon>
                <v-icon v-if="quest.isUnderstand" large color="green">mdi-emoticon-outline</v-icon>
                <v-icon v-else large color="red">mdi-emoticon-frown-outline</v-icon>
              </v-btn>

              <v-btn large icon>
                <v-icon large :color="getColorIcon(quest.isWritten)">mdi-pencil</v-icon>
              </v-btn>

              <v-btn large icon>
                <v-icon large :color="getColorIcon(quest.isLearned)">mdi-thumb-up</v-icon>
              </v-btn>

              <v-spacer></v-spacer>

              <v-btn large icon>
                <v-icon large>mdi-update</v-icon>
              </v-btn>
            </v-card-actions>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </div>
</template>

<script>
export default {
  props: {
    exam: Object
  },
  data: () => ({
    colorQuestion: "#006064",
    questions: null
  }),

  mounted() {
    if (this.exam.id === 1) {
      this.questions = [
        {
          id: 1,
          text: "Вопрос лин 111111111111111 11111111111 1111111111",
          isUnderstand: true,
          isWritten: false
        },
        { id: 2, text: "Вопрос лин 2", isUnderstand: false, isWritten: false },
        { id: 3, text: "Вопрос лин 3", isUnderstand: true, isWritten: true },
        { id: 4, text: "Вопрос лин 4", isUnderstand: false, isWritten: false },
        { id: 5, text: "Вопрос лин 5", isUnderstand: false, isWritten: false },
        { id: 6, text: "Вопрос лин 6", isUnderstand: false, isWritten: false }
      ];
    } else {
      this.questions = [
        { id: 7, text: "Вопрос мат 1", isUnderstand: true, isWritten: true },
        { id: 8, text: "Вопрос мат 2", isUnderstand: true, isWritten: false },
        { id: 9, text: "Вопрос мат 3", isUnderstand: false, isWritten: false },
        { id: 10, text: "Вопрос мат 4", isUnderstand: false, isWritten: false }
      ];
    }
  },

  methods: {
    getColorIcon(status) {
      return status ? "green" : "red";
    }
  }
};
</script>
